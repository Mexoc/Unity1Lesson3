using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Settings;

    void Start()
    {
        Settings.SetActive(false);
        MainMenu.SetActive(true);
        DontDestroyOnLoad(this.gameObject);
        
    }

    public void ShowMainMenu()
    {
        MainMenu.SetActive(true);
        Settings.SetActive(false);
    }

    public void ShowSettings()
    {
        MainMenu.SetActive(true);
        Settings.SetActive(true);
    }

    public void Back()
    {
        MainMenu.SetActive(true);
        Settings.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        MainMenu.SetActive(false);
        Settings.SetActive(false);        
        if (Application.loadedLevel == 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    void Update()
    {
        
    }
}
