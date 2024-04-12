using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.VFX;
using TMPro;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FoodPrefab;

    public TextMeshProUGUI scoreText; 
    private int score = 0;
    
    public float timer = 0.0f;
    void Start()
    {
        Spawn();

        Debug.Log("swe");

      

    }
    private void Update()
    {
     
        if (BordersHitBox.FoodColl) 
        {
            
            Spawn();
            Destroy(GameObject.Find("Food(Clone)"));
            score += 1;
            scoreText.text = score.ToString(); // Обновляем текст счета
          

        }
        if (Movement.IsFoodInside)
        {
            Destroy(GameObject.Find("Food(Clone)"));
            Spawn();
            Movement.IsFoodInside = false;
        }
        if (Movement.dir == 5) 
        {
            if (score != 0)
            {
                score = 0;
                scoreText.text = score.ToString();
            }
          
        }
      
        
    }
    public void Spawn()
    {
        int randX = UnityEngine.Random.Range(0, 46);
        int randY = UnityEngine.Random.Range(0, 20);
        float finalX = 0;
        float finalY = 0;

        finalX += randX - 22.5f;
        finalY += randY - 10.5f;

       Instantiate(FoodPrefab, new Vector3(finalX, finalY, -1), Quaternion.identity);
    }
   


}
