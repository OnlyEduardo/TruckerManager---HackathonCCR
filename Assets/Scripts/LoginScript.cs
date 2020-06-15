using UnityEngine;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
    public InputField inputEmail;
    public InputField inputPass;

    public Text Error;

    private bool canLogin = true;

    public void Login()
    {
        try
        {
            if (!inputEmail.text.Equals(SaveData.email))
                canLogin = false;
            if (!inputPass.text.Equals(SaveData.senha))
                canLogin = false;

            if (canLogin)
            {
                Error.enabled = false;
                SceneController.LoadStaticScene("MenuScene");
            }
            else
                Error.enabled = true;
        } catch { }     
    }
}
