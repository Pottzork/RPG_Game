using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeSkill : MonoBehaviour
{
    Ray myRay;
    RaycastHit hit;
    public GameObject ObjectToSpawn;

    void Update()
    {
        
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast (myRay, out hit))
        {
            
            if (Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.H))
            {

                Instantiate(ObjectToSpawn, hit.point, Quaternion.identity);
            }
        }
        
    }

}
