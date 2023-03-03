using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefabHorloge;
    public GameObject gamObjRandomSpawnPoint;
    public int x,y,z;

    public int nombreHorloges;
    public float spawnRadius;
    public float spawnCollisionCheckRadius;

    void Awake()
    {
        Instantiate(prefabHorloge, new Vector3(x,y,z), Quaternion.identity);
    }

    void Start()
    {

        for(int x = 0; x < nombreHorloges; )
        {
            Vector3 spawnPoint = gamObjRandomSpawnPoint.transform.position + Random.insideUnitSphere * spawnRadius;

            if(!Physics.CheckSphere(spawnPoint, spawnCollisionCheckRadius))
            {
                x = x+1;
                Instantiate(prefabHorloge,spawnPoint,Random.rotation);
            }
        }

    }

}
