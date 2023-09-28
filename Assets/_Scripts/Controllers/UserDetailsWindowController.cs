using System;
using deVoid.UIFramework;
using deVoid.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Controllers
{
    public class ViewUserDetailsSignal : ASignal<UserDetailsProperty> { }

    [Serializable]
    public class UserDetailsProperty : WindowProperties
    {
        public readonly Result _user;
        public readonly Sprite _userImage;
        public UserDetailsProperty(Result user, Sprite _userImage)
        {
            _user = user;
            this._userImage = _userImage;
        }
    }
    public class UserDetailsWindowController : AWindowController<UserDetailsProperty>
    {
        [SerializeField] private TextMeshProUGUI _userNameTitle;
        [SerializeField] private Image _userImage;
        [SerializeField] private TextMeshProUGUI _firstName;
        [SerializeField] private TextMeshProUGUI _lastName;
        [SerializeField] private TextMeshProUGUI _age;
        [SerializeField] private TextMeshProUGUI _email;
        [SerializeField] private TextMeshProUGUI _city;
        [SerializeField] private TextMeshProUGUI _country;
        [SerializeField] private Button _backBtn;
        protected override void OnPropertiesSet()
        {
            _userNameTitle.text = Properties._user.login.username;
            _userImage.sprite = Properties._userImage;
            _firstName.text = Properties._user.name.first;
            _lastName.text = Properties._user.name.last;
            _age.text = Properties._user.dob.age.ToString();
            _email.text = Properties._user.email;
            _city.text = Properties._user.location.city;
            _country.text = Properties._user.location.country;
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            _backBtn.onClick.AddListener(HandleBackBtn);
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            _backBtn.onClick.RemoveListener(HandleBackBtn);
        }

        private void HandleBackBtn()
        {
            UI_Close();
        }
    }
}