using com.ootii.Cameras;
using Invector.vCharacterController.TopDownShooter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationsForTito : MonoBehaviour
{
    [SerializeField]
    Vector3 positionTitoDown;
    [SerializeField]
    Vector3 positionTitoUp;
    [SerializeField]
    Quaternion targetRotation;
    public float speed = 0.1f;
    public float rotSpeed = 5f;

    CameraController camCont;

    [SerializeField]
    Transform titoAnchor;
    [SerializeField]
    Transform playerAnchor;

    Vector3 startingPos;
    Quaternion startingRot;

    private void Awake()
    {
        camCont = GetComponent<CameraController>();
        startingRot = transform.rotation;
    }
    
    [EditorButton]
    public void MoveToATitoPos()
    {
        startingPos = transform.position;
        camCont.IsInternalUpdateEnabled = false;
        StartCoroutine(MoveToTito());
    }


    public IEnumerator MoveToTito()
    {
        while(Vector3.Distance(this.transform.position,positionTitoDown)>0.02f)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, positionTitoDown, speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);

            yield return null;
        }

        yield return new WaitForSeconds(15);

        while (Vector3.Distance(this.transform.position, positionTitoUp) > 0.02f)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, positionTitoUp, speed/2 * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, startingRot, rotSpeed* Time.deltaTime);

            yield return null;
        }

         camCont.Anchor = titoAnchor;

         camCont.IsInternalUpdateEnabled = true;


    }

    internal void MoveToAPlayerPos()
    {
        camCont.IsInternalUpdateEnabled = false;
        StartCoroutine(MoveToAPlayer());
    }

    public IEnumerator MoveToAPlayer()
    {
        while (Vector3.Distance(this.transform.position, startingPos) > 0.02f)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, startingPos, speed * Time.deltaTime);

            yield return null;
        }
        camCont.Anchor = playerAnchor;
        playerAnchor.parent.GetComponent<vTopDownShooterInput>().SetLockAllInput(false);
       // playerAnchor.parent.GetComponent<vTopDownShooterInput>().enabled = true;

        camCont.IsInternalUpdateEnabled = true;


    }




}
