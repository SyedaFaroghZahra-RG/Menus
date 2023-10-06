using _Scripts.Core;
using _Scripts.Services;
using deVoid.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Controllers
{
    //controller of user prefab. contains Image of user, UserName, a button to view details of user
    public class UserDataController : MonoBehaviour
    {
        private Result user;
        private string _ImageID;
        [SerializeField] private TextMeshProUGUI _userName;
        [SerializeField] private Image _ProfilePic;
        [SerializeField] private Button _ViewDetailsButton;

        //only public variable(property) in whole code base, couldn't figure out how to make it private; used in only AllUsersWindowController
        public string UserID { get; set; }

        private void Awake()
        {
            _ViewDetailsButton.onClick.AddListener(UI_ViewDetails);
        }
        
        private void OnEnable()
        {
            //Only set data if coming from start window, if not coming from start window means no new data, so no need to set data again
            if(ServiceLocator.Instance.GetService<IUserService>().getterCallAPI())
                SetUserData();
        }

        private void SetUserData()
        {
            //extract data of this user from in memory dictionary
             user = ServiceLocator.Instance.GetService<IUserService>().GetUserData<Result>(UserID);
             
            //display username on screen
            _userName.text = user.login.username;
            //get imageId (which is also url of image)
            _ImageID = user.picture.medium;
            
            //if image already exists in memory dict, display it on screen
            if (ServiceLocator.Instance.GetService<IImageService>().ContainsKey(_ImageID))
            {
                _ProfilePic.sprite = ServiceLocator.Instance.GetService<IImageService>().GetImage(_ImageID);
            }
            //else download image, display on screen and store in dict
            else
            {
                ServiceLocator.Instance.GetService<IImageService>().GetImageTexture(user.picture.medium).Done(sprite =>
                {
                    _ProfilePic.sprite = sprite;
                    ServiceLocator.Instance.GetService<IImageService>().SetImage(sprite, _ImageID);
                });
            }
        }
        private void UI_ViewDetails()
        {
            Signals.Get<ViewUserDetailsSignal>().Dispatch(GetClickedUser());
        }

        //setting properties for user detail screen
        private UserDetailsProperty GetClickedUser()
        {
            Result user = ServiceLocator.Instance.GetService<IUserService>().GetUserData<Result>(UserID);
            Sprite userImage = ServiceLocator.Instance.GetService<IImageService>().GetImage(user.picture.medium);
            UserDetailsProperty UserProps = new UserDetailsProperty(user, userImage);
            return UserProps;
        }
    }
}
