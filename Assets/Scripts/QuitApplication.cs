using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("youve hit escape");
            Application.Quit();
        }
    }
}
