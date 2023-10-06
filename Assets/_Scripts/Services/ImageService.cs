using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using RSG;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

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
        
        public IPromise<Sprite> GetImageTexture(string uri)
       {
           var promise = new Promise<Sprite>();
           using (var client = new WebClient())
           {
               client.DownloadDataCompleted += (sender, e) =>
               {
                   if (e.Error != null)
                   {
                       promise.Reject(e.Error);
                   }
                   else
                   {
                       Texture2D myTexture = new Texture2D(2,2);
                       myTexture.LoadImage(e.Result);
                       Sprite sprite = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height),
                           new Vector2(0.5f, 0.5f));
                       promise.Resolve(sprite);
                   }
               };
               client.DownloadDataAsync(new Uri(uri), null);
           }
           return promise;
       }
       
    }
}