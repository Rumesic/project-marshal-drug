using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotLimit : MonoBehaviour
{

    [SerializeField] bool lockX;
    [SerializeField] bool lockY;
    [SerializeField] bool lockZ;

    [SerializeField] bool lockParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Transform t = lockParent ? transform.parent : transform;
        float rotX = (lockX) ? 0 : t.localRotation.x;
        float rotY = (lockY) ? 0 : t.localRotation.y;
        float rotZ = (lockZ) ? 0 : t.localRotation.z;

        t.localRotation = new Quaternion(rotX, rotY, rotZ, t.localRotation.w);
    }

    public void LockX(bool value)
    {
        lockX = value;
    }

    public void LockY(bool value)
    {
        lockY = value;
    }

    public void LockZ(bool value)
    {
        lockZ = value;
    }
}
