using com.ootii.Cameras;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarEventTito : MonoBehaviour
{
    public UnityEvent enableZombiesAndPlayer;

    [SerializeField] AudioSource sourceCar;
    [SerializeField] AudioSource sourceGovor;
    [SerializeField] Animation anim;

    [SerializeField] float trajanjeGovora;
    [SerializeField] float trajanjePaljenja;

    [SerializeField] CameraController cam;
    [SerializeField] Transform player;
    [SerializeField] Transform limuzina;

    [ContextMenu("StartGovor")]
    public void StartGovor()
    {
        cam.Anchor = limuzina;
        DisableZombiesAndPlayer();
        sourceGovor.PlayOneShot(sourceGovor.clip);


      /*  camera.SetParent(Camera.main.transform.parent);
        camera.transform.position = Camera.main.transform.position;

        camera.gameObject.SetActive(true);*/
        FunctionTimer.Create(StartCar, trajanjeGovora);
    }

    [ContextMenu("StartCar")]
    public void StartCar()
    {

        sourceCar.PlayOneShot(sourceCar.clip);
        FunctionTimer.Create(StartCarAnim, trajanjePaljenja);
    }
    [ContextMenu("CarDriveAway")]
    public void StartCarAnim()
    {
        anim.Play("CarDriveAway");

    }

    public void CardDroveAway()
    {
        enableZombiesAndPlayer?.Invoke();
        cam.Anchor = player;
    }

    public void DisableZombiesAndPlayer()
    {

    }


}
