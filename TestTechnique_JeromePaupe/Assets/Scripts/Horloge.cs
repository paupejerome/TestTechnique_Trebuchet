using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Horloge : MonoBehaviour
{
    const float degreesParHeure = 30f;
    const float degreesParMinute = 6f;

    public Transform transformHeures, tranformMinutes;
    public GameObject aiguilleH1,aiguilleH2,aiguilleH3,aiguilleM1,aiguilleM2,aiguilleM3;

    private void Awake()
    {
        DateTime dateTemps = DateTime.Now;
        transformHeures.localRotation = Quaternion.Euler(0f, dateTemps.Hour * degreesParHeure, 0f);
        tranformMinutes.localRotation = Quaternion.Euler(0f, dateTemps.Minute * degreesParMinute, 0f);
        SelectionAiguilles();
    }

    private void Update()
    {
        TimeSpan dateTemps = DateTime.Now.TimeOfDay;
        transformHeures.localRotation = Quaternion.Euler(0f, (float)dateTemps.TotalHours * degreesParHeure, 0f);
        tranformMinutes.localRotation = Quaternion.Euler(0f, (float)dateTemps.TotalMinutes * degreesParMinute, 0f);
    }
    
    private void SelectionAiguilles()
    {
        UnityEngine.Random.seed = System.DateTime.Now.Millisecond;
        int randomNumber = (int)UnityEngine.Random.Range(1,3);

        if(randomNumber==1)
        {
            aiguilleH1.SetActive(true);
            aiguilleM1.SetActive(true);
        }
        if(randomNumber==2)
        {
            aiguilleH2.SetActive(true);
            aiguilleM2.SetActive(true);          
        }
        if(randomNumber==3)
        {
            aiguilleH3.SetActive(true);
            aiguilleM3.SetActive(true);
        }
        
        Debug.Log("randomNumber : " + randomNumber);
    }
}
