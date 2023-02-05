using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEventTito : MonoBehaviour
{
    [SerializeField] AudioSource sourceCar;
    [SerializeField] AudioSource sourceGovor;
    [SerializeField] Animation anim;

    [SerializeField] float trajanjeGovora;
    [SerializeField] float trajanjePaljenja;
    // Start is called before the first frame update
    void Start()
    {

    }

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
        anim.Play();
        EnableZombiesAndPlayer();
    }

    public void EnableZombiesAndPlayer()
    {

    }

    public void DisableZombiesAndPlayer()
    {

    }


}
