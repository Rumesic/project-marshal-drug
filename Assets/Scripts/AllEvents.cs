using Invector.vCharacterController;
using Invector.vCharacterController.TopDownShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEvents : MonoBehaviour
{
    [SerializeField]
    Animator dialogAnim;

    [SerializeField]
    vTopDownShooterInput inputScript;
    [SerializeField]
    vThirdPersonController moveControl;


    public void VoiceActPrvi()
    {
        //activate audio source 

    }

    public void FirstWaweEvent()
    {
        FunctionTimer.Create(EndFirstWaweEvent, 3);
        //audio source activate 
        //Counter za zombije i timer
        //trigger voice line 
        // �koljic 



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
        FunctionTimer.Create(EndSecondWaweEvent, 5);

        //audio source activate 
        //trigger voice line 

       


    }

    public void EndSecondWaweEvent()
    {
        
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
     
    public void DeathEvent()
    {
        //dode maca na vratanca death

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