using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace _Scripts.Services
{
    public class ImageService : IImageService
    {
        private Dictionary<string, Sprite> images = new Dictionary<string, Sprite>();

        public void  SetImage(Sprite Image, string key)
        {
            if (!images.ContainsKey(key))
            {
                images.Add(key, Image);
            }
        }
        public Sprite GetImage(string key)
        {
            if (!images.ContainsKey(key))
            {
                Debug.Log("Wrong Id");
            }
            return images[key];
        }

        public bool ContainsKey(string key)
        {
            if (images.ContainsKey(key))
                return true;
            return false;
        }

        public IEnumerator GetImageTexture(string uri, Action<Sprite> callback)
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(uri);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                Sprite sprite = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height),
                    new Vector2(0.5f, 0.5f));
                callback(sprite);
            }
        }
    }
}