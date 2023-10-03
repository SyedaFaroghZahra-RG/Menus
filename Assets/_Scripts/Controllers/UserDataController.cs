using System;
using System.Collections;
using System.Threading.Tasks;
using _Scripts.Core;
using _Scripts.Services;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace _Scripts.Controllers
{
    public class UserDataController : MonoBehaviour
    {
        private Result user;
        private string _ImageID;
        [SerializeField] private TextMeshProUGUI _userName;
        [SerializeField] private Image _ProfilePic;

        public string UserID { get; set; }

        private void Start()
        {
            SetUserData();
        }

        private void SetUserData()
        {
            user = ServiceLocator.Instance.GetService<IUserService>().GetUserData(UserID);
            _ImageID = user.picture.medium;
            _userName.text = user.login.username;
            if (ServiceLocator.Instance.GetService<IImageService>().ContainsKey(_ImageID))
            {
                _ProfilePic.sprite = ServiceLocator.Instance.GetService<IImageService>().GetImage(_ImageID);
            }
            else
            {
                StartCoroutine(ServiceLocator.Instance.GetService<IImageService>().GetImageTexture(user.picture.medium, (sprite) => {
                    _ProfilePic.sprite = sprite;
                    ServiceLocator.Instance.GetService<IUserService>().SetUserData(user, UserID);
                    ServiceLocator.Instance.GetService<IImageService>().SetImage(sprite, _ImageID);
                }));
            }
        }
    }
}
