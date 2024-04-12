using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{


  
     public static bool lose = false;

    void Update()
    {

        if (Movement.dir == 5)
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                BordersHitBox.BorderColl = false;
                GameObject.Find("Menu").transform.position = new Vector3(GameObject.Find("Menu").transform.position.x, GameObject.Find("Menu").transform.position.y + 350f, 0);
                Movement.dir = 0;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
