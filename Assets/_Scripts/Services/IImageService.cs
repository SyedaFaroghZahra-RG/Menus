using UnityEngine;

namespace _Scripts.Services
{
    public interface IImageService
    {
        public void SetImage(string UserImageuri, int key);
        public Sprite GetImage(int key);
    }
}