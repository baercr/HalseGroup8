using System.Collections;
using System.Collections.Generic;
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
        // StartCoroutine(GetDate());
        // StartCoroutine(GetUsers());
        // StartCoroutine(Login("test1","123456"));
        // StartCoroutine(RegisterUser("testAdd","123456"));
    }

    IEnumerator GetUsers() {
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

    IEnumerator GetDate()
    {
        UnityWebRequest myWr = UnityWebRequest.Get("http://localhost/UnityDB/GetDate.php");
        yield return myWr.SendWebRequest();

        if (myWr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(myWr.error);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            // Show results as text
            Debug.Log(myWr.downloadHandler.text);

            // Show results as binary data
            byte[] results = myWr.downloadHandler.data;
        }
    }

   
    public IEnumerator Login(string playerName, string playerPassword)
    {
        List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        form.Add(new MultipartFormDataSection("loginUser", playerName));
        form.Add(new MultipartFormDataSection("loginPassword", playerPassword));

        UnityWebRequest myWr = UnityWebRequest.Post("http://localhost/UnityDB/Login.php", form);
        yield return myWr.SendWebRequest();

        if (myWr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(myWr.error);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            // Show results as text
            Debug.Log(myWr.downloadHandler.text);

            // Show results as binary data
            byte[] results = myWr.downloadHandler.data;
        }
    }

    public IEnumerator RegisterUser(string playerName, string playerPassword)
    {
        List<IMultipartFormSection> form = new List<IMultipartFormSection>();
        form.Add(new MultipartFormDataSection("loginUser", playerName));
        form.Add(new MultipartFormDataSection("loginPassword", playerPassword));

        UnityWebRequest myWr = UnityWebRequest.Post("http://localhost/UnityDB/RegisterUser.php", form);
        yield return myWr.SendWebRequest();

        if (myWr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(myWr.error);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
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
