using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField inputName;
    public TMP_InputField inputPassword;
    public Button btnLogin;

    // Start is called before the first frame update
    void Start() {
        btnLogin.onClick.AddListener(() => {
            StartCoroutine(Main.Instance.Web.Login(inputName.text, inputPassword.text));
        });
    }

}
