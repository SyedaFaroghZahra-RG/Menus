using System;
using System.Collections;
using UnityEngine;

namespace _Scripts.Services
{
    public interface IImageService
    {
        public void SetImage(Sprite Image, string key);
        public Sprite GetImage(string key);
        public IEnumerator GetImageTexture(string uri, Action<Sprite> callback);
    }
}