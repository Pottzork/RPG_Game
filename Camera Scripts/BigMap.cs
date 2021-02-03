using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BigMap : MonoBehaviour
{

    public GameObject UIBigMap;
    private bool toggle = false;

    public Transform player;


    
    void LateUpdate()
    {

        if(player != null)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                ActivateBigMap();
            }

            Vector3 newPos = player.position;
            newPos.y = transform.position.y;
            transform.position = newPos;
        }
        else
        {
            return;
        }
        

        

    }

    public void ActivateBigMap()
    {
        toggle = !toggle;
        UIBigMap.SetActive(toggle);
    }

   
}
