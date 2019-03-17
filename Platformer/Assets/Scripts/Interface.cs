using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Settings;
    public GameObject _start;
    public GameObject _settings;
    public GameObject _exit;
    public GameObject _text;

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
        //MainMenu.SetActive(true);
        _start.SetActive(false);
        _settings.SetActive(false);
        _exit.SetActive(false);
        Settings.SetActive(true);
        _text.SetActive(true);      
    }

    public void Back()
    {
        _start.SetActive(true);
        _settings.SetActive(true);
        _exit.SetActive(true);
        //MainMenu.SetActive(true);
        Settings.SetActive(false);
        _text.SetActive(false);
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
