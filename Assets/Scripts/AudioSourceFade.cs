using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioSourceFade 
{
    public static IEnumerator FadeAudio(AudioSource source,float targetVolume,float duration)
    {

        

        float currentTime = 0;
        float start = source.volume;


        while(duration > currentTime)
        {

            currentTime += Time.deltaTime;
            source.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return new WaitForEndOfFrame();
        }

         

        yield break;
    }

    //to fade in and out in one swoop
    public static IEnumerator FadeInAndOutAudio(AudioSource source,AudioClip newClip, float targetVolume, float durationOut, float durationIn)
    {

     
        float currentTime = 0;
        float start = source.volume;

        //fade out with the duration 
        while (durationOut > currentTime)
         {

            currentTime += Time.deltaTime;
            source.volume = Mathf.Lerp(start, 0, currentTime / durationOut);
            yield return new WaitForEndOfFrame();
        }
        source.clip = newClip;
        source.Play();
        //reset the variables
         currentTime = 0;
        start = source.volume;

        //fade in with durationIn
        while (durationIn > currentTime)
        {

            currentTime += Time.deltaTime;
            source.volume = Mathf.Lerp(start, targetVolume, currentTime / durationIn);
            yield return new WaitForEndOfFrame();
        }

        yield break;
    }


}


