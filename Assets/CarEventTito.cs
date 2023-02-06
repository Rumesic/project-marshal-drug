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
  

    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("StartGovor")]
    public void StartGovor()
    {
        DisableZombiesAndPlayer();
        sourceGovor.PlayOneShot(sourceGovor.clip);
        FunctionTimer.Create(StartCar, trajanjeGovora);
    }

    public void StartCar()
    {
        sourceCar.PlayOneShot(sourceCar.clip);
        FunctionTimer.Create(StartCarAnim, trajanjePaljenja);
    }

    public void StartCarAnim()
    {
        anim.Play("CarDriveAway");
        EnableZombiesAndPlayer();
    }

    public void EnableZombiesAndPlayer()
    {
        enableZombiesAndPlayer?.Invoke();
    }

    public void DisableZombiesAndPlayer()
    {

    }


}
