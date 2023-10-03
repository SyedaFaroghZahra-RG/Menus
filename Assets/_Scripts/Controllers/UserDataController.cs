using _Scripts.Core;
using _Scripts.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Controllers
{
    public class UserDataController : MonoBehaviour
    {
        private Result user;
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
            _userName.text = user.login.username;
            if (ServiceLocator.Instance.GetService<IImageService>().ContainsKey(UserID))
            {
                _ProfilePic.sprite = ServiceLocator.Instance.GetService<IImageService>().GetImage(UserID);
            }
            else
            {
                StartCoroutine(ServiceLocator.Instance.GetService<IImageService>().GetImageTexture(user.picture.medium, (sprite) => {
                    _ProfilePic.sprite = sprite;
                    ServiceLocator.Instance.GetService<IUserService>().SetUserData(user, UserID);
                    ServiceLocator.Instance.GetService<IImageService>().SetImage(sprite, UserID);
                }));
            }
        }
    }
}
