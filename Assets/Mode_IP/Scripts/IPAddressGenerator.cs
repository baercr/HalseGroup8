using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IPAddressGenerator : MonoBehaviour
{
    public TextMeshProUGUI txtBusinessIP;
    public TextMeshProUGUI txtTestIP;

    private string ipBusiness;
    private string ipTest;

    int octect;
    private string ip;

    // Start is called before the first frame update
    void Start() {
        int num;

        CreateIP();
        ipBusiness = ip;
        txtBusinessIP.text = ipBusiness;
        // Debug.Log("The company's IP is: " + ipBusiness);

        num = Random.Range(0, 3);

        if (num != 0)
        {
            CreateIP();
            ipTest = ip;
            txtTestIP.text = ipTest;
            // Debug.Log("The IP to test is: " + ipTest);
        }

        else
        {
            ipTest = ipBusiness;
            txtTestIP.text = ipTest;
        }

    }

    void Update() { 
        
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
