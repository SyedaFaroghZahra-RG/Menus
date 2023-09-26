using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.APICalls
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