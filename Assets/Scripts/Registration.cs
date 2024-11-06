using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField passwordField;

    public Button btnRegister;

    void Start() {
        StartCoroutine(Register());
    }

    IEnumerator Register() {
        //List<IMultipartFormSection> form = new List<IMultipartFormSection>();
            //form.Add(new MultipartFormDataSection("name", nameField.text));
            //form.Add(new MultipartFormDataSection("password", passwordField.text));

        UnityWebRequest myWr = UnityWebRequest.Get("http://localhost/UnityDB/GetUsers.php");
            yield return myWr.SendWebRequest();

        if (myWr.result == UnityWebRequest.Result.ConnectionError) {
            Debug.Log(myWr.error);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else {
            // Show results as text
            Debug.Log(myWr.downloadHandler.text);

            // Show results as binary data
            byte[] results = myWr.downloadHandler.data;
        }
    }

    public void VerifyInputs() {
        btnRegister.interactable = (nameField.text.Length >= 3 && passwordField.text.Length >= 5);
    }
}
