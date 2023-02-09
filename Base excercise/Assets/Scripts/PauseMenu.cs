using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject helpScreen;
    [SerializeField] CinemachineBrain cinemachineBrain;
    bool onPause = false;
    float timeScaleBeforePause = 1f;

    void Start()
    {
        onPause = false;
        timeScaleBeforePause = Time.timeScale;
        pauseScreen.SetActive(false);
        helpScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!onPause)
            {
                Pause();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                helpScreen.SetActive(false);
            }
            else
            {
                Unpause();
                Cursor.visible = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (pauseScreen.activeSelf)
            {
                pauseScreen.SetActive(false);
            }
            helpScreen.SetActive(!helpScreen.activeSelf);
        }
    }

    void Pause()
    {
        onPause = true;
        pauseScreen.SetActive(onPause);
        cinemachineBrain.enabled = !onPause;
        timeScaleBeforePause = Time.timeScale;
        Time.timeScale = 0.01f;
    }

    void Unpause()
    {
        onPause = false;
        pauseScreen.SetActive(onPause);
        cinemachineBrain.enabled = !onPause;
        Time.timeScale = 1f;
    }
}
