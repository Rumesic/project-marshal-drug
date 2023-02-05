using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieCounter : MonoBehaviour
{
    [SerializeField]
    UnityEvent eventValGotov;
    bool activatedOnce = false;
    private void Update()
    {
        if(activatedOnce)
        {
       
          return; }

        if(transform.childCount<8)
        {
            activatedOnce = true;
            eventValGotov?.Invoke();
        }
    }


}
