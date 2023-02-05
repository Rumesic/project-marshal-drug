using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenSwitcher : MonoBehaviour
{
    [SerializeField] Light[] lights;
    [SerializeField] float switchTime = 0.1f;

    [SerializeField] float minIntensity = 0.1f;
    [SerializeField] float maxIntensity = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("WaitForSeconds");
    }

    IEnumerator WaitForSeconds()
    { 
        yield return new WaitForSeconds(switchTime);
        SwitchLights();
    }

    void SwitchLights()
    {
        if(lights[0].intensity != minIntensity)
        {
            lights[0].intensity = minIntensity;
            lights[1].intensity = maxIntensity;
        }
        else
        {
            lights[1].intensity = minIntensity;
            lights[0].intensity = maxIntensity;
        }
        StartCoroutine("WaitForSeconds");
    }
}
