using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieCounter : MonoBehaviour
{
    [SerializeField]
    UnityEvent eventValGotov;
    bool activatedOnce = false;
    public int numberCounter = 8;


    private void Update()
    {
        if(activatedOnce)
        {
          return; }

        if(transform.childCount< numberCounter)
        {
            activatedOnce = true;
            eventValGotov?.Invoke();
        }
    }


}
