using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDungeon : MonoBehaviour
{
    private int nextSceneToLoad;
    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
