using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInst : MonoBehaviour
{
    public GameObject gridElement;
    public int numOfElements;
    // Start is called before the first frame update
    void Start()
    {
        // Check if gridElement is set
        if (gridElement == null)
        {
            Debug.LogError("Grid Element is not assigned in the Inspector.");
            return;
        }

        // Duplicate grid elements based on the numberOfDuplicates
        for (int i = 0; i < numOfElements; i++)
        {
            // Create a new instance of the grid element
            GameObject newElement = Instantiate(gridElement, transform);

            // Optionally, you can set the name or other properties of the new element
            newElement.name = gridElement.name + "_" + (i + 1);

            // Adjust the position of the new element (optional)
            // Example: Place the new elements in a row
            newElement.transform.localPosition = new Vector3(i * 1.0f, 0, 0); // Adjust the spacing as needed
        }
        
    }
}
