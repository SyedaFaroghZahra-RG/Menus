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
        
        private async void SetData()
        { 
            u = GetUserData.GetNewUser();

            for (int i = 0; i < 30; i++)
            {
                _userName = u.users[i].username;
                _imageUri = u.users[i].image;
                var user = Instantiate(_User, _parent.transform);
                user.GetComponentInChildren<TextMeshProUGUI>().text = _userName;
                await GetTexture(_imageUri);
                user.GetComponentInChildren<Image>().sprite = _userImage;
                user.GetComponentInChildren<Button>().name = u.users[i].id.ToString();
            }
        }
        private async Task GetTexture(string uri)
        {
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

        public void UI_ViewDetails()
        {
            Signals.Get<ViewUserDetailsSignal>().Dispatch(GetClickedUser());
        }

        private UserDetailsProperty GetClickedUser()
        {
            int id = int.Parse(EventSystem.current.currentSelectedGameObject.name);
           
            Debug.Log(id);
            User ClickedUser = u.users[id];
            UserDetailsProperty UserProps = new UserDetailsProperty(ClickedUser);
            return UserProps;
        }
    }
}
