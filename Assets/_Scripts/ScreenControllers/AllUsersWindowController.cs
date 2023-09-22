using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Scripts.APICalls;
using deVoid.UIFramework;
using deVoid.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace _Scripts.ScreenControllers
{
    public class AllUsersWindowController : AWindowController
    {
        [SerializeField] private GameObject _parent;
        [SerializeField] private GameObject _User;
        private UserData u;
        private string _userName;
        private string _imageUri;
        private Sprite _userImage;
        
        protected override void Awake()
        {
            base.Awake();
            SetData();
        }
        
        private async void  SetData()
        { 
            u = GetUserData.GetNewUser();
            foreach (var t in u.users)
            {
                _userName = t.username;
                _imageUri = t.image;
                var user = Instantiate(_User, _parent.transform);
                user.GetComponentInChildren<TextMeshProUGUI>().text = _userName;
                await GetTexture(_imageUri); 
                user.GetComponentInChildren<Image>().sprite = _userImage;
                StoreUserData(t, _userImage, user);
            }
        }

        private void StoreUserData(User u, Sprite userImage, GameObject user)
        {
            user.GetComponent<UserForPrefab>().user = u;
            user.GetComponent<UserForPrefab>()._ProfilePic = userImage;
        }
        private async Task GetTexture(string uri) {
          using UnityWebRequest www = UnityWebRequestTexture.GetTexture(uri);
          var operation =  www.SendWebRequest();

          while (!operation.isDone)
              await Task.Yield();
            
          if (www.result != UnityWebRequest.Result.Success)
          {
              Debug.Log(www.error);
          }
          else
          {
              Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
              _userImage = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height),
                  new Vector2(0.5f, 0.5f));
          }
        }
    }
}
