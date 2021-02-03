using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    //This script is to make spells dissapear after time so they don't exist forever in the game
    //For example you can choose how long the heal should appear and be active(like renew 4s)
    public float timer = 2f;
    
    void Start()
    {
        Destroy(gameObject, timer);
    }


}
