using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    ScoreManagement mng;
    Drop drp;
    DropForOpponent drpopn;
    private GameObject temp;

    public void execute(enumerable.skillNames name){
        Debug.Log("Masuk");
        switch(name){
            case enumerable.skillNames.burn :
            Debug.Log("Execute Burn");
            break;
            case enumerable.skillNames.mirror :
               
            //cari gameObject yang memiliki Script ScoreManagement
            // mng = FindObjectOfType<ScoreManagement>();
            //mng.Scoreplayer1 = 0;
                Debug.Log("Execute Mirror");
            break;
            case enumerable.skillNames.shock :
            Debug.Log("Execute Shock");
            break;
            case enumerable.skillNames.none :
                Debug.Log("NONE");
                break;

            
        }
    }
}
