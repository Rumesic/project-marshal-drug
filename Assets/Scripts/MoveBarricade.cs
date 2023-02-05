using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBarricade : MonoBehaviour
{

    public Vector3 positionClose;
    public float speed = 5f;

    Vector3 startingPosition;
    Vector3 endPosition;

    bool openIt = false;
    public void Awake()
    {
        startingPosition = this.transform.position;
        endPosition = this.transform.position;
    }

    [ContextMenu("OpenBarricade")]
    public void OpenBarricade()
    {
        endPosition = this.transform.position - positionClose;
    }

    [ContextMenu("CloseBarricade")]
    public void CloseBarricade()
    {
        openIt = false;
        endPosition = startingPosition;
    }

    public void Update()
    {
        if(transform.position != endPosition)
        {
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, endPosition, step);
        }
      
        
    }

}
