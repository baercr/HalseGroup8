using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiftSelect : MonoBehaviour
{ 
    public Button shiftTile;

    // Start is called before the first frame update
    void Start() {
        shiftTile.onClick.AddListener(() => {
            //StartCoroutine(Main.Instance.Web.GetLevelData(shiftTile.onClick));
        });
    }

}