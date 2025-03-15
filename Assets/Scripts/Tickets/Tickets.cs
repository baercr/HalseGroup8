using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tickets : MonoBehaviour
{
    public bool Ticket1 = false;        // true = ticket completed
    public bool Ticket2 = false;        // true = ticket completed
    public bool Ticket3 = false;        // true = ticket completed

    void Update()
    {
        // Active Ticket Logic
        //
        // Ticket 1 is active
        if(Ticket1 == false &&  Ticket2 == false && Ticket3 == false)
        {
            Debug.Log("Ticket 1 is active");
        }

        // Ticket 2 is active
        if (Ticket1 == true && Ticket2 == false && Ticket3 == false)
        {
            Debug.Log("Ticket 2 is active");
        }

        // Ticket 3 is active
        if (Ticket1 == true && Ticket2 == true && Ticket3 == false)
        {
            Debug.Log("Ticket 3 is active");
        }
    }
}
