using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UserDataController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _userName;
    [SerializeField] private Image _ProfilePic;
    public User user { get; private set; }
    public Sprite isprite { get; private set; }
    public async void SetUserData(User u)
    {
         user = u;
        _userName.text = user.username;
         Sprite image =  await GetTexture(u.image);
        _ProfilePic.sprite = image;
         isprite = image;
    }
    
    private async Task<Sprite> GetTexture(string uri) {
        using UnityWebRequest www = UnityWebRequestTexture.GetTexture(uri);
        var operation =  www.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield();
            
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            return null;
        }
        else
        {
            Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            return Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height),
                new Vector2(0.5f, 0.5f));
        }
    }
}
