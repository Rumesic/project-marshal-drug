using Invector.vCharacterController.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTalkingScript : MonoBehaviour
{

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip[] clips;

    [SerializeField]
    vSimpleMeleeAI_Controller simpleController;

    private void Start()
    {

        var randomRepeatTime = Random.Range(3, 5);
        InvokeRepeating("ZombieTalk", randomRepeatTime, randomRepeatTime);
    }

    public void ZombieTalk()
    {
        if(simpleController.isDead)
        { return; }
        
        var random = Random.Range(0, 7);
        if (random>3)
        {
            audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
        }
    }

}
