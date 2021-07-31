﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject controlsScreen;

    bool pauseState;
    bool controlsState;

    private void Awake()
    {
        pauseScreen.SetActive(false);

        pauseState = false;
        controlsState = false;
    }

    void Update()
    {
        InputPause();
    }

    void InputPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseState = !pauseState;

            if(pauseState == true)
            {
                ActivatePause();
            }
            else
            {
                DisablePause();
            }
        }
    }

    public void ActivatePause()
    {
        pauseScreen.SetActive(true);

        Time.timeScale = 0f;
    }

    public void DisablePause()
    {
        pauseScreen.SetActive(false);

        Time.timeScale = 1f;
    }

    public void StateControlsScreen()
    {
        controlsState = !controlsState;

        if (controlsState)
        {
            controlsScreen.SetActive(true);
        }
        else
        {
            controlsScreen.SetActive(false);
        }
    }

    public void RestartAndDisablePause(string scene)
    {
        pauseScreen.SetActive(false);

        Time.timeScale = 1f;

        SceneManager.LoadScene(scene);
    }
}