using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField]
    GameObject canvasZasluge;

    [SerializeField]
    AudioSource musicSource;

    public void LoadLevel()
    {
        StartCoroutine(AudioSourceFade.FadeAudio(musicSource, 0, 1f));

        Invoke("LoadScene", 1.5f);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
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
