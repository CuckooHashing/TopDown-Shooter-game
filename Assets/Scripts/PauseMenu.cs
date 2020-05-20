using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool paused = false;
    public GameObject Pause_Menu;
	
	void Update () {
	
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        Pause_Menu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    void Pause()
    {
        Pause_Menu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }
}
