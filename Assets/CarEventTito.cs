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

    [SerializeField] Transform camera;
  

    [ContextMenu("StartGovor")]
    public void StartGovor()
    {

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
    }

    public void DisableZombiesAndPlayer()
    {

    }


}
