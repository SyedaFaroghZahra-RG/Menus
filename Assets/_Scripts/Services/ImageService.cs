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
        
    }
}