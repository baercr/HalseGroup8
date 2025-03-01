using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEditor.Compilation;
using UnityEngine;

public class Interpreter : MonoBehaviour
{
    List<string> response = new List<string>();

    public List<string> Interpret(string userInput)
    {
        response.Clear();

        string[] args = userInput.Split();

        if (args[0] == "help")
        {
            response.Add("If you want to use the terminal, type \"boop\" ");
            response.Add("This is the second line that we are returning");

            return response;
        }
        if (args[0] == "boop")
        {
            response.Add("Thank you for using the terminal");

            return response;
        }
        else
        {
            response.Add("Command not recognized. Type help for a list of commands");

            return response;
        }
    }
}
