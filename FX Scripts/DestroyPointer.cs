using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointer : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        if (Vector3.Distance(transform.position, player.position) <= .8f)
        {
            Destroy(gameObject);
        }
    }
} //class














