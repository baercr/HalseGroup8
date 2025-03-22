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

        int trueIndex = Random.Range(0, numOfElements);

        // Create grid elements
        for (int i = 0; i < numOfElements; i++)
        {
            // Instantiate the grid element
            GameObject newElement = Instantiate(gridElement, transform);

            // Name the new element
            newElement.name = gridElement.name + "_" + (i + 1);

            // Adjust the position of the new element (if needed)
            newElement.transform.localPosition = new Vector3(i * 1.0f, 0, 0);

            // Pass index and boolean value to GridElementScript
            GridElementScript elementScript = newElement.GetComponent<GridElementScript>();
            if (elementScript != null)
            {
                elementScript.isActive = (i == trueIndex); // True for the selected element
            }
        }
    }
}
   

