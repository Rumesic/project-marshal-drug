using Invector.vCharacterController;
using Invector.vCharacterController.TopDownShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AllEvents : MonoBehaviour
{
    [SerializeField]
    Animator dialogAnim;

    [SerializeField]
    vTopDownShooterInput inputScript;
    [SerializeField]
    vThirdPersonController moveControl;

    [SerializeField]
    AudioMixer audioMixer;
    public void Awake()
    {
        StartCoroutine(AudioSourceFade.FadeAudioMixer(audioMixer, "GameSounds", 1, 1f));
    }

    public void VoiceActPrvi()
    {
        //activate audio source 

    }

    public void FirstWaweEvent()
    {
        FunctionTimer.Create(EndFirstWaweEvent, 30);
        //audio source activate 
        //Counter za zombije i timer
        //trigger voice line 
        // Školjic 



    }



    public void EndFirstWaweEvent()
    {
        Debug.Log("End First Wawe event");
        // open new zone
        // Explosion whatever
    }


    public void SecondWaweEvent()
    {
        // Cont pozicija

        // kill most of the zombies and/or timer
        FunctionTimer.Create(EndSecondWaweEvent, 50);

        //audio source activate 
        //trigger voice line 

       


    }

    public void EndSecondWaweEvent()
    {
        //barikade se uniste
    }

    public void StartBossFight()
    {  
        //mrtvi kanal

       //player loses control
       //animation starts 
       //bring black screen top and down
       //profile picture placeholder fade in
       //Animate text left to right
       //Add voice

        dialogAnim.SetTrigger("DialogIntro");
    }
  


    public void StopAnimator()
    {
        dialogAnim.SetTrigger("StopAnimator");
    }

    public void LoseControlPlayer()
    {
        inputScript.SetLockAllInput(true);
    }

    public void GainControlPlayer()
    {
        inputScript.SetLockAllInput(false);
    }



  
}
