using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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


    public static IEnumerator FadeAudioMixer(AudioMixer audioMixer, string exposedParam, float duration, float targetVolume)
    {
        float currentTime = 0;
        float currentVol;
        audioMixer.GetFloat(exposedParam, out currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1);
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            audioMixer.SetFloat(exposedParam, Mathf.Log10(newVol) * 20);
            yield return null;
        }
        yield break;
    }

}


