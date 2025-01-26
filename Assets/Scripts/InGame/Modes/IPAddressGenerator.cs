using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IPAddressGenerator : MonoBehaviour
{
    public TextMeshProUGUI ipAddress;
    int octect;
    private string ip;

    private string ipConfirm;
    private string ipTest;
    

    // Start is called before the first frame update
    void Start() {

        CreateIP();
        ipConfirm = ip;
        ipAddress.text = ipConfirm;
        Debug.Log("The company's IP is: " + ipConfirm);

        CreateIP();
        ipTest = ip;
        Debug.Log("The IP to test is: " + ipTest);

    }

    private string CreateIP() {

        int[] ipOctect = new int[4];

        for (int i = 0; i < 4; i++)
        {
            octect = Random.Range(0, 256);

            ipOctect[i] = octect;
        }

        ip = ipOctect[0] + "." + ipOctect[1] + "." + ipOctect[2] + "." + ipOctect[3];
        return ip; 
    }
}
