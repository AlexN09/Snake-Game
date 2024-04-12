
using System.Collections.Generic;
//using Unity.Android.Gradle;
using Unity.Properties;

using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject objectPrefab;


    public List<GameObject> BodyParts = new List<GameObject>();
    public float delayTime;
    private float timer = 0.0f;
    private float lastExecutionTime;
    private float interval = 0.07f;
    public static byte dir = 0; //1 - Down, 2 - Up, 3 - Right, 4 - Left. 

    public static bool IsFoodInside = false;

    private void Start()
    {
        lastExecutionTime = Time.time;
        for (int i = 0; i < 2; i++)
        {

            GameObject newpart = Instantiate(objectPrefab, new Vector3(-15.499f + i, -1.48f, -1), Quaternion.identity); ;
            
            BodyParts.Add(newpart);
        }
     
    }

    
    void Update()
    {
        if (dir == 5)
        {
            return;
        }
        BodyParts[BodyParts.Count - 1].name = "HEAD";
        BodyParts[BodyParts.Count - 1].name = "HEAD";
        timer += Time.deltaTime;
      
        if (Time.time - lastExecutionTime >= interval)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && dir != 2)
            {
                dir = 1;
                lastExecutionTime = Time.time;  // —брасываем таймер после изменени€ направлени€
                delayTime = 0.075f;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && dir != 1)
            {
                dir = 2;
                lastExecutionTime = Time.time; // —брасываем таймер после изменени€ направлени€
                delayTime = 0.075f;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && dir != 4)
            {
                dir = 3;
                lastExecutionTime = Time.time;  // —брасываем таймер после изменени€ направлени€
                delayTime = 0.075f;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && dir != 3)
            {
                dir = 4;
                lastExecutionTime = Time.time; ; // —брасываем таймер после изменени€ направлени€
                delayTime = 0.075f;
            }
            
        }
        if (dir == 1)
        {
            if (timer >= delayTime)
            {
                MoveRight();
                timer = 0.0f;

            }

        }
        if (dir == 2)
        {
            if (timer >= delayTime)
            {
                MoveLeft();
                timer = 0.0f;
            }

        }
        if (dir == 3)
        {
            if (timer >= delayTime)
            {
                MoveUp();
                timer = 0.0f;
            }
        }
        if (dir == 4)
        {
            if (timer >= delayTime)
            {
                MoveDown();
                timer = 0.0f;
            }
        }
        if (BordersHitBox.FoodColl)
        {
            GameObject newpart = Instantiate(objectPrefab, new Vector3(BodyParts[BodyParts.Count - 1].transform.position.x, BodyParts[BodyParts.Count - 1].transform.position.y, -1), Quaternion.identity);
            BodyParts.Add(newpart);


            BordersHitBox.FoodColl = false;
        }
        foreach (GameObject bodyPart in BodyParts)
        {
            if (bodyPart.transform.position == GameObject.Find("Food(Clone)").transform.position)
            {
                IsFoodInside = true;
            }
        }
        if (BordersHitBox.BorderColl)
        {
            dir = 5;
           
                GameObject.Find("Menu").transform.position = new Vector3(GameObject.Find("Menu").transform.position.x, GameObject.Find("Menu").transform.position.y - 350f, 0);
                for (int i = 0; i < BodyParts.Count; i++)
                {
                    Object.Destroy(BodyParts[i]);
                    
                }
                BodyParts.Clear();
                
                for (int i = 0; i < 2; i++)
                {

                    GameObject newpart = Instantiate(objectPrefab, new Vector3(-15.499f + i, -1.48f, -1), Quaternion.identity); ;
                    
                    BodyParts.Add(newpart);
                }
            
            

        }
        BodyParts[BodyParts.Count - 1].name = "HEAD";
        BodyParts[BodyParts.Count - 1].name = "HEAD";


    }
    private void MoveRight()
    {
        Object.Destroy(BodyParts[0]);
        BodyParts.RemoveAt(0);
        GameObject newpart = Instantiate(objectPrefab, new Vector3(BodyParts[BodyParts.Count - 1].transform.position.x + 1, BodyParts[BodyParts.Count - 1].transform.position.y, -1), Quaternion.identity);
        newpart.name = "HEAD";
        BodyParts[BodyParts.Count - 1].name = "Bodypart(Clone)";
        BodyParts.Add(newpart);

    }
    private void MoveLeft()
    {
        Object.Destroy(BodyParts[0]);
        BodyParts.RemoveAt(0);
        GameObject newpart = Instantiate(objectPrefab, new Vector3(BodyParts[BodyParts.Count - 1].transform.position.x - 1, BodyParts[BodyParts.Count - 1].transform.position.y, -1), Quaternion.identity);
        newpart.name = "HEAD";
        BodyParts[BodyParts.Count - 1].name = "Bodypart(Clone)";

        BodyParts.Add(newpart);
    }
    private void MoveUp()
    {
        Object.Destroy(BodyParts[0]);
        BodyParts.RemoveAt(0);
        GameObject newpart = Instantiate(objectPrefab, new Vector3(BodyParts[BodyParts.Count - 1].transform.position.x, BodyParts[BodyParts.Count - 1].transform.position.y + 1, -1), Quaternion.identity);
        newpart.name = "HEAD";
        BodyParts[BodyParts.Count - 1].name = "Bodypart(Clone)";
        BodyParts.Add(newpart);
    }
    private void MoveDown()
    {
        Object.Destroy(BodyParts[0]);
        BodyParts.RemoveAt(0);
        GameObject newpart = Instantiate(objectPrefab, new Vector3(BodyParts[BodyParts.Count - 1].transform.position.x, BodyParts[BodyParts.Count - 1].transform.position.y - 1, -1), Quaternion.identity);
        newpart.name = "HEAD";
        BodyParts[BodyParts.Count - 1].name = "Bodypart(Clone)";
        BodyParts.Add(newpart);
    }
}