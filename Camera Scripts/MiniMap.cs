using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;



    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newPos = player.position;
            newPos.y = transform.position.y;
            transform.position = newPos;
        }
        
        
    }

    public void ZoomIn()
    {
        this.GetComponent<Camera>().orthographicSize -= 2;
    }

    public void ZoomOut()
    {
        this.GetComponent<Camera>().orthographicSize += 2;
    }
}
