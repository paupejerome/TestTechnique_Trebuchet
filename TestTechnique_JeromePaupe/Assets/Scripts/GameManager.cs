using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefabHorloge;
    public GameObject gamObjRandomSpawnPoint;
    public AudioSource source;
    public int x,y,z; //coordonne du instantiate awake
    public int nombreHorloges;
    public float spawnRadius;
    public float spawnCollisionCheckRadius;

    private bool firstInstanciateAttempt = false;

    void Awake()
    {
        Instantiate(prefabHorloge, new Vector3(x, y, z), Quaternion.identity);
    }

    void Start()
    {
        for(int x = 0; x < nombreHorloges; )
        {
            spawnHorloge();
            x = x + 1;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            spawnHorloge();
            EventManager.OnSpacePressed();
        }
    }


    void spawnHorloge()
    {
        if(!firstInstanciateAttempt)
        {
            firstInstanciateAttempt = true;
        }

        Vector3 spawnPoint = gamObjRandomSpawnPoint.transform.position + Random.insideUnitSphere * spawnRadius;

        if(!Physics.CheckSphere(spawnPoint, spawnCollisionCheckRadius))
        {
            Instantiate(prefabHorloge, spawnPoint, Quaternion.identity);
            firstInstanciateAttempt = false;
        }
        else
        {
            spawnHorloge();
        }

    }


    private void OnEnable()
    {
        EventManager.SpacePressed += EventManagerOnSpacePressed;
    }
    private void OnDisable()
    {
        EventManager.SpacePressed -= EventManagerOnSpacePressed;
    }
    private void EventManagerOnSpacePressed()
    {
        source.Play(0);
    }

}
