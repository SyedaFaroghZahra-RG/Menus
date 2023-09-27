using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace _Scripts.Services
{
    public class ImageService : IImageService
    {
        private Dictionary<int, Sprite> images = new Dictionary<int, Sprite>();
        private Sprite UserImage;

        public async void  SetImage(string UserImageuri, int key)
        {
            UserImage = await GetTexture(UserImageuri);
            if (!images.ContainsKey(key))
            {
                images.Add(key,UserImage);
            }
        }
        public Sprite GetImage(int key)
        {
            if (!images.ContainsKey(key))
            {
                Debug.Log("Wrong Id");
            }
            return images[key];
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
}