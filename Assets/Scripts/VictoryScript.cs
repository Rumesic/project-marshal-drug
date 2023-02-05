using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class VictoryScript : MonoBehaviour
{
    [SerializeField]
    GameObject loadingCanvas;


    [SerializeField]
    AudioMixer audioMixer;

    public Texture2D cursor;
    public void Awake()
    {
        StartCoroutine(AudioSourceFade.FadeAudioMixer(audioMixer, "GameSounds", 1, -1f));
        Cursor.visible = true;

        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        //Set Cursor to not be visible
    }

    public void LoadLevel()
    {

        loadingCanvas.gameObject.SetActive(true);
        loadingCanvas.GetComponent<Animator>().SetTrigger("LoadOut");

        Invoke("LoadScene", 1.5f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
