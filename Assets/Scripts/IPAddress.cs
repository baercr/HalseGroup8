using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IPAddressManager : MonoBehaviour
{
    public string[] ipAddresses; // Array to hold IP addresses

    void Start()
    {
        // Example usage: Get a random IP address from the array
        string randomIPAddress = GetRandomIPAddress();
        Debug.Log("Random IP Address: " + randomIPAddress);
    }

    // Method to get a random IP address from the array
    public string GetRandomIPAddress()
    {
        if (ipAddresses.Length == 0)
        {
            Debug.LogWarning("IP address array is empty!");
            return string.Empty;
        }

        int randomIndex = Random.Range(0, ipAddresses.Length);
        return ipAddresses[randomIndex];
    }

    // Method to get a specific IP address by index
    public string GetIPAddressByIndex(int index)
    {
        if (index < 0 || index >= ipAddresses.Length)
        {
            Debug.LogWarning("Index out of range!");
            return string.Empty;
        }

        return ipAddresses[index];
    }
}
