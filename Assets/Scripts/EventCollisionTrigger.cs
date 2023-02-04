using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCollisionTrigger : MonoBehaviour
{
    public UnityEvent startEvent;

    public bool triggerOnlyOnce = true;
    int triggeredTimes = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            return;
        }
        if (triggerOnlyOnce && triggeredTimes > 0)
        {
            return;
        }
      
        triggeredTimes++;
        startEvent?.Invoke();
        
    }
}
