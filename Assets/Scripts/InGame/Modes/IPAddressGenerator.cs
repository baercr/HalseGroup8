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

    // Start is called before the first frame update
    void Start()
    {
        int[] ipOctect = new int[4];

        for (int i = 0; i < 4; i++) {
            octect = Random.Range(0,256);

            ipOctect[i] = octect;
        }

        //ipOctect.IntToString();

        Debug.Log("Your random IP address is: " + ipOctect[0] + "." + ipOctect[1] + "." + ipOctect[2] + "." + ipOctect[3]);
        //Debug.Log("Your random IP address is: " + ipOctect);
    }
}
