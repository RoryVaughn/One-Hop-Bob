using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool IsPaused;
    public GameObject PauseMenuUI;
    public GameObject SettingsMenuUI;
    public GameObject PurpleText;



    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        SettingsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        SettingsMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }


    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelComplete()
    {
        PurpleText.SetActive(true);
        Time.timeScale = 0.4f;
    }


    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {

                Resume();
            }

            else
            {
                Pause();
            }
        }

    }
}
