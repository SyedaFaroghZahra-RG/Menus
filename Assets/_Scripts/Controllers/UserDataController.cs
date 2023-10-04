using _Scripts.Core;
using _Scripts.Services;
using deVoid.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Controllers
{
    public class UserDataController : MonoBehaviour
    {
        private Result user;
        private string _ImageID;
        [SerializeField] private TextMeshProUGUI _userName;
        [SerializeField] private Image _ProfilePic;
        [SerializeField] private Button _ViewDetailsButton;

        public string UserID { get; set; }

        private void Awake()
        {
            _ViewDetailsButton.onClick.AddListener(UI_ViewDetails);
        }
        
        private void OnEnable()
        {
            SetUserData();
        }

        private void SetUserData()
        {
            user = ServiceLocator.Instance.GetService<IUserService>().GetUserData<Result>(UserID);
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
        private void UI_ViewDetails()
        {
            Signals.Get<ViewUserDetailsSignal>().Dispatch(GetClickedUser());
        }

        private UserDetailsProperty GetClickedUser()
        {
            Result user = ServiceLocator.Instance.GetService<IUserService>().GetUserData<Result>(UserID);
            Sprite userImage = ServiceLocator.Instance.GetService<IImageService>().GetImage(user.picture.medium);
            UserDetailsProperty UserProps = new UserDetailsProperty(user, userImage);
            return UserProps;
        }
    }
}
