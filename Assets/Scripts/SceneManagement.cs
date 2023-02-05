using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField]
    GameObject canvasZasluge;

    [SerializeField]
    GameObject loadingCanvas;

    [SerializeField]
    AudioSource musicSource;

    [SerializeField]
    AudioMixer audioMixer;

    public void Awake()
    {
        StartCoroutine(AudioSourceFade.FadeAudioMixer(audioMixer, "GameSounds", 1, -1f));

    }
    public void LoadLevel()
    {



        if (musicSource)
        {
            StartCoroutine(AudioSourceFade.FadeAudio(musicSource, 0, 1f));
        }

        loadingCanvas.gameObject.SetActive(true);
        loadingCanvas.GetComponent<Animator>().SetTrigger("LoadOut");

        Invoke("LoadScene", 1.5f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }


 

    public void Quit()
    {
        Application.Quit();
    }


    public void OpenZasluge()
    {
        canvasZasluge.gameObject.SetActive(true);
    }
}
