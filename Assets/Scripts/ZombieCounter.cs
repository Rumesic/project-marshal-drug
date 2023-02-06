using Invector.vCharacterController.AI;
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

    public void ActivateZombies()
    {
        var controlls = GetComponentsInChildren<vSimpleMeleeAI_Controller>();
        foreach(var a in controlls)
        {
            a.enabled = true;
        }
    }

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
