using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class Registration : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField passwordField;

    public Button btnRegister;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        form.Add(new MultipartFormDataSection("name", nameField.text));
        form.Add(new MultipartFormDataSection("password", passwordField.text));

        UnityWebRequest myWr = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
        yield return myWr.SendWebRequest();
        if (myWr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(myWr.error);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
             Debug.Log(myWr.downloadHandler.text);
        }
    }

    public void VerifyInputs()
    {
        btnRegister.interactable = (nameField.text.Length >= 3 && passwordField.text.Length >= 5);
    }
}
