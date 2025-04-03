using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInst : MonoBehaviour
{
    public GameObject gridElement; // Prefab for grid elements
    public int numOfElements;      // Number of elements to generate

    public void Start()
    {
        RefreshGrid();
    }

    public void RefreshGrid()
    {
    

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Regenerate the grid elements
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        if (gridElement == null)
        {
            Debug.LogError("Grid Element prefab is not assigned.");
            return;
        }

        int trueIndex = Random.Range(0, numOfElements);

        for (int i = 0; i < numOfElements; i++)
        {
            // Instantiate and position new elements
            GameObject newElement = Instantiate(gridElement, transform);
            newElement.name = gridElement.name + "_" + (i + 1);
            newElement.transform.localPosition = new Vector3(i * 1.0f, 0, 0);

            // Assign active state (only one element is active)
            GridElementScript elementScript = newElement.GetComponent<GridElementScript>();
            if (elementScript != null)
            {
                elementScript.isActive = (i == trueIndex);
            }
        }
    }
}
