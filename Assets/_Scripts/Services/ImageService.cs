using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace _Scripts.Services
{
    public class ImageService : IImageService
    {
        private Dictionary<int, Sprite> images = new Dictionary<int, Sprite>();

        public void  SetImage(Sprite UserImage, int key)
        {
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
        
    }
}