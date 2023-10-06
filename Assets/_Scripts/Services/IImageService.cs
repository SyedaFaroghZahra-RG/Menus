using System;
using System.Collections;
using RSG;
using UnityEngine;

namespace _Scripts.Services
{
    public interface IImageService
    {
        public void SetImage(Sprite Image, string key);
        public Sprite GetImage(string key);
        public bool ContainsKey(string key);
        //public IEnumerator GetImageTexture(string uri, Action<Sprite> callback);
        public IPromise<Sprite> GetImageTexture(string uri);
    }
}