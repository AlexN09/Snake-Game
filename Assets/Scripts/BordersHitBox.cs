using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;

using UnityEngine;

public class BordersHitBox : MonoBehaviour
{
    public static bool FoodColl = false;
    public static bool BorderColl = false;
    public static bool ElementColl = false;

   
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {


        
        if (other.name == "Food(Clone)")
        {
            FoodColl = true;
            PlayMultipleSounds.canPlayFood = true;
        }
        if (other.name == "border1" || other.name == "border2" || other.name == "border3" || other.name == "ScoreTab" || other.name == "Bodypart(Clone)")
        {
            BorderColl = true;
            PlayMultipleSounds.canPlayBorder = true; 
            
        }
        if (other.name == "Bodypart(Clone)")
        {
            ElementColl = true;
        }
        Debug.Log(other.name);
        
    }
}

