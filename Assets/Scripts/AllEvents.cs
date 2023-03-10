using com.ootii.Cameras;
using Invector.vCharacterController;
using Invector.vCharacterController.TopDownShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AllEvents : MonoBehaviour
{
   
    [Header("Rijeka Event End")]
    public MoveBarricade RijekaValBarricadeEnd;
    public Animator RijekaLitTheWay;
    public GameObject zombieCounterRijeka;
    [Header("Cont Event End")]
    public MoveBarricade ContValBarricadeEnd;
    public Animator ContLitTheWay;
    public GameObject zombieCounterCont;
    [Header("Tito event")]
    public CarEventTito titoEvents;
    public Transform titoFollow;
    public GameObject zombieCounterTito;
    public CameraController camerCont;

    Animator dialogAnim;

    [SerializeField]
    vTopDownShooterInput inputScript;

    [SerializeField]
    AudioMixer audioMixer;

    [SerializeField]
    GameObject victoryCanvas;

    public void Awake()
    {
        StartCoroutine(AudioSourceFade.FadeAudioMixer(audioMixer, "GameSounds", 1, 1f));
       
    }

    private void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void VoiceActPrvi()
    {
        //activate audio source 

    }

    public void FirstWaweEvent()
    {
        //audio source activate 

       

        //trigger voice line 
        // ?koljic 



    }



    public void EndFirstWaweEvent()
    {

        RijekaValBarricadeEnd.OpenBarricade();
        RijekaLitTheWay.SetTrigger("TurnOn");

        Debug.Log("End First Wawe event");
        // open new zone
        // Explosion whatever
    }


    public void SecondWaweEvent()
    {
        // Cont pozicija

        // kill most of the zombies and/or timer
        //  FunctionTimer.Create(EndSecondWaweEvent, 50);
        zombieCounterRijeka.SetActive(false);
        zombieCounterCont.SetActive(true);
        RijekaLitTheWay.SetTrigger("TurnOff");
        RijekaValBarricadeEnd.CloseBarricade();
        Debug.Log("STart second Wawe event");

        //audio source activate 
        //trigger voice line 


    }

    public void EndSecondWaweEvent()
    {
       
        ContValBarricadeEnd.OpenBarricade();
        ContLitTheWay.SetTrigger("TurnOn");
        //barikade se uniste
        //zombieCounterTito.gameObject.SetActive(true);

    }

    [ContextMenu("StartBossFight")]
    public void StartBossFight()
    {
        //StartVictoryEvent();

        //mrtvi kanal
        zombieCounterCont.SetActive(false);
       // camerCont.Anchor = titoEvents.transform;
        //player loses control
        //animation starts 
        //bring black screen top and down
        //profile picture placeholder fade in
        //Animate text left to right

        //Add voice
        ContValBarricadeEnd.CloseBarricade();
        ContLitTheWay.SetTrigger("TurnOff");

        zombieCounterTito.SetActive(true);
        LoseControlPlayer();
        //camerCont.GetComponent<CameraAnimationsForTito>().MoveToATitoPos();

        titoEvents.StartGovor();
        //camerCont.Anchor = titoFollow;

        //  dialogAnim.SetTrigger("DialogIntro");

        Debug.Log("Start Boss fight");
      
    }

    public void StartVictoryEvent()
    {
        victoryCanvas.gameObject.SetActive(true);
    }




    public void StopAnimator()
    {
        dialogAnim.SetTrigger("StopAnimator");
    }

    public void LoseControlPlayer()
    {
        inputScript.SetLockAllInput(true);
       // inputScript.enabled = false;
    }

    public void GainControlPlayer()
    {
        vTopDownShooterInput input = FindObjectOfType<vTopDownShooterInput>();
        input.SetLockAllInput(false);
        //camerCont.GetComponent<CameraAnimationsForTito>().MoveToAPlayerPos();
    }



  
}
