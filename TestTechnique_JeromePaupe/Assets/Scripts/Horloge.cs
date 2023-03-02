using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Horloge : MonoBehaviour
{
    const float degreesParHeure = 30f;
    const float degreesParMinute = 6f;

    public Transform transformHeures, tranformMinutes;

    private void Awake()
    {
        DateTime dateTemps = DateTime.Now;
        transformHeures.localRotation = Quaternion.Euler(0f, dateTemps.Hour * degreesParHeure, 0f);
        tranformMinutes.localRotation = Quaternion.Euler(0f, dateTemps.Minute * degreesParMinute, 0f);
    }

    private void Update()
    {
        TimeSpan dateTemps = DateTime.Now.TimeOfDay;
        transformHeures.localRotation = Quaternion.Euler(0f, (float)dateTemps.TotalHours * degreesParHeure, 0f);
        tranformMinutes.localRotation = Quaternion.Euler(0f, (float)dateTemps.TotalMinutes * degreesParMinute, 0f);
    }
    
}
