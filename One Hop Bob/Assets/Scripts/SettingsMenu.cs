using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour {

    

    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions; 

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        //this loops through and adds a computer's own reloutions rather than giving preset ones
        List<string> choices = new List<string>();
        int currentRes = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            choices.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentRes = i;
            }
        }

        resolutionDropdown.AddOptions(choices);
        resolutionDropdown.value = currentRes;
        resolutionDropdown.RefreshShownValue();


    }

    public void PlayGame()
    {
        SceneManager.LoadScene("1 hop");
    }

    public void QuitGame()
    {
        Debug.Log("attemting to quit");
        Application.Quit();
    }

    public void SetMasterVolume (float Master)
    {
        audioMixer.SetFloat("MasterVolume", Master);
    }
    
    public void SetQuality (int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }
}
