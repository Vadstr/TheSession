using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    public GameObject pauseMenu;
    private static GameObject PauseMenu; 
    private static bool inPause;

    private void Start()
    {
        inPause = false;
        PauseMenu = pauseMenu;
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!inPause)
            {
                Time.timeScale = 0;
                inPause = true;
                PauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                inPause = false;
                PauseMenu.SetActive(false);
            }
        }
    }

    public static void UnPause()
    {
        Time.timeScale = 1;
        inPause = false;
        PauseMenu.SetActive(false);
    }
}
