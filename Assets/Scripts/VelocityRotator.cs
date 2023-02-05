using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityRotator : MonoBehaviour
{

    [SerializeField] Transform parent;

    [Range(0, 5)]
    [SerializeField] float speed = 1;
    float velocity;
    Vector3 worldVelocity;
    Vector3 localVelocity;
    Vector3 previous;

    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateVelocity();
        Rotate();
    }

    void CalculateVelocity()
    {
        worldVelocity = ((parent.position - previous) / Time.deltaTime);
        previous = parent.position;

        localVelocity = transform.parent.InverseTransformDirection(worldVelocity);
        velocity = localVelocity.x;
    }

    void Rotate()
    {
        transform.Rotate(0, 0, velocity * speed * -1);
    }

    private void OnDrawGizmos()
    {
        //Vector3 velocity = (transform.position - pos) / Time.deltaTime;
        //pos = transform.position;
        //Gizmos.DrawSphere(transform.position + velocity, 0.5f);
    }
}
