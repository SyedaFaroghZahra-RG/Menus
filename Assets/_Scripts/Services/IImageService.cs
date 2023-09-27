using UnityEngine;

namespace _Scripts.Services
{
    public interface IImageService
    {
        public void SetImage(Sprite UserImage, int key);
        public Sprite GetImage(int key);
    }
}