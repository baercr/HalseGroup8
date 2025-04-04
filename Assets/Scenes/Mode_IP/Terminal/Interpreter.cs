using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using UnityEditor.Compilation;
using UnityEngine;
using random = UnityEngine.Random;

public class Interpreter : MonoBehaviour
{
    Dictionary<string, string> colors = new Dictionary<string, string>()
    {
        {"black", "#021b21" },
        {"gray", "#555d71" },
        {"red", "#ff5879" },
        {"yellow", "#f2f1b9" },
        {"blue", "#9ed9d8" },
        {"purple", "#d926ff" },
        {"orange", "#ef5847" }
    };

    List<string> response = new List<string>();

    public string ipPlayer;
    public string ipToDelete;

    bool isDeleted;

    public void Start()
    {
        ipPlayer = CreateIP();
        ipToDelete = CreateIP();
    }

    public List<string> Interpret(string userInput)
    {
        response.Clear();

        string[] args = userInput.Split();


        //HELP
        //
        if (args[0] == "help")
        {
            ListEntry("help", "returns a list of commands");
            ListEntry("sudo 'command'", "grants admin privledges");
            ListEntry("ipconfig", "ip management");
            ListEntry("arp -a", "scans network for IP addresses");
            ListEntry("arp -ipdisconnect", "disconnects unwanted IP devices");
        }


        //IPCONFIG NO ADMIN
        //
        if (args[0] == "ipconfig")
        {
            response.Add("'ipconfig' command requires admin privledges");

            return response;
        }


        //IPCONFIG ADMIN
        //
        if (args[0] == "sudo" && args[1] == "ipconfig")
        {
            response.Add("\r\n\r\n\r\n\r\n\r\n" +
                "Wireless LAN adapter Local Area Connection* 10:\r\n\r\n   " +
                "IPv4 Address. . . . . . . . . . . : " + ipPlayer + " \r\n   " +
                "Subnet Mask . . . . . . . . . . . : 255.255.255.0 \r\n   " +
                "Default Gateway . . . . . . . . . : 192.168.86.1");
            response.Add("");
            response.Add("");
            response.Add("");
            response.Add("");
            response.Add("");

            return response;
        }


        //ARP NO ADMIN
        //
        if (args[0] == "arp" && args[1] == "-a")
        {
            response.Add("'arp -a' command requires admin privledges");

            return response;
        }


        //ARP ADMIN IP NOT DELETED
        //
        if (args[0] == "sudo" && args[1] == "arp" && args[2] == "-a" && !isDeleted)
        {
            response.Add(" \r\n\r\n\r\n" +
                "Internet Address       Type\r\n  " +
                "192.168.86.1           dynamic \r\n  " +
                ipPlayer + "           dynamic \r\n  " +
                ipToDelete + "          dynamic");

            response.Add("");
            response.Add("");
            response.Add("");

            return response;
        }

        //ARP ADMIN IP DELETED
        //
        if (args[0] == "sudo" && args[1] == "arp" && args[2] == "-a" && isDeleted)
        {
            response.Add(" \r\n\r\n\r\n" +
                "Internet Address       Type\r\n  " +
                "192.168.86.1           dynamic \r\n  " +
                ipPlayer + "           dynamic \r\n  ");

            response.Add("");
            response.Add("");
            response.Add("");

            return response;
        }

        //ARP IPDISCONNECT NO ADMIN
        //
        if (args[0] == "arp" && args[1] == "-ipdisconnect")
        {
            response.Add("'arp -ipdisconnect' command requires admin privledges");

            return response;
        }


        //ARP IPDISCONNECT ADMIN
        //
        if (args[0] == "sudo" && args[1] == "arp" && args[2] == "-ipdisconnect" && args[3] == ipToDelete)
        {
            isDeleted = true;
            response.Add("IP address " + ipToDelete + " has been disconnected.");

            return response;
        }


        //ASCII
        //
        if (args[0] == "ascii")
        {
            LoadTitle("ascii.txt", "red", 2);
            return response;
        }

        else
        {
            response.Add("Command not recognized. Type help for a list of commands");

            return response;
        }
    }

    public string ColorString(string s, string color)
    {
        string leftTag = "<color=" + color + ">";
        string rightTag = "</color=" + color + ">";

        return leftTag + s + rightTag;
    }

    void ListEntry(string a,  string b)
    {
        response.Add(ColorString(a, colors["orange"]) + ": " + ColorString(b, colors["yellow"]));
    }

    void LoadTitle(string path, string color, int spacing)
    {
        StreamReader file = new StreamReader(Path.Combine(Application.streamingAssetsPath, path));

        for (int i = 0; i < spacing; i++)
        {
            response.Add("");
        }

        while(!file.EndOfStream)
        {
            response.Add(ColorString(file.ReadLine(), colors[color]));
        }

        for(int i = 0; i < spacing; i++)
        {
            response.Add("");
        }

        file.Close();
    }

    public string CreateIP()
    {
        int octect;
        string ip;

        int[] ipOctect = new int[4];

        for (int i = 0; i < 4; i++)
        {
            octect = random.Range(0, 256);

            ipOctect[i] = octect;
        }

        ip = ipOctect[0] + "." + ipOctect[1] + "." + ipOctect[2] + "." + ipOctect[3];
        return ip;
    }
}
