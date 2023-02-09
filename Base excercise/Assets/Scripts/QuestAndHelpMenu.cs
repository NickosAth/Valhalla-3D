using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class QuestAndHelpMenu : MonoBehaviour
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
        helpScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F1))
        {
            if (!onPause)
            {
                Pause();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                pauseScreen.SetActive(false);
            }
            else
            {
                Unpause();
                Cursor.visible = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (helpScreen.activeSelf)
            {
                helpScreen.SetActive(false);
            }
            pauseScreen.SetActive(!pauseScreen.activeSelf);
        }
    }

    void Pause()
    {
        onPause = true;
        helpScreen.SetActive(onPause);
        cinemachineBrain.enabled = !onPause;
        timeScaleBeforePause = Time.timeScale;
        Time.timeScale = 0.01f;
    }

    void Unpause()
    {
        onPause = false;
        helpScreen.SetActive(onPause);
        cinemachineBrain.enabled = !onPause;
        Time.timeScale = 1f;
    }
}
