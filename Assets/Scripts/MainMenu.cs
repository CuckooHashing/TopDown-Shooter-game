using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip audioClip;

    public void PlayClip()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void PlayGame( int scene)
    {
        PlayClip();
        SceneManager.LoadScene(scene);

    }

    public void QuitGame()
    {
        PlayClip();
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
