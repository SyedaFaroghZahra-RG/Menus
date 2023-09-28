using System.Threading.Tasks;
using _Scripts.Core;
using _Scripts.Services;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UserDataController : MonoBehaviour
{
    private Result user;
    [SerializeField] private TextMeshProUGUI _userName;
    [SerializeField] private Image _ProfilePic;
    public string UserID { get; private set; }

    public async void SetUserData(Result u)
    {
         user = u;
         UserID = u.id.value;
        _userName.text = user.login.username;
        _ProfilePic.sprite =  await GetTexture(u.picture.medium);
         ServiceLocator.Instance.GetService<IUserService>().SetUserData(user, UserID);
         ServiceLocator.Instance.GetService<IImageService>().SetImage(_ProfilePic.sprite, UserID);
    }
    
    private async Task<Sprite> GetTexture(string uri) {
        using UnityWebRequest www = UnityWebRequestTexture.GetTexture(uri);
        var operation =  www.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield();
            
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            return null;
        }
        else
        {
            Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            return Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height),
                new Vector2(0.5f, 0.5f));
        }
    }
}