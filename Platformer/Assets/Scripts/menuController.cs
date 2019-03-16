using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour
{
    public Interface _menu;

    // Start is called before the first frame update
    void Start()
    {
        _menu = FindObjectOfType<Interface>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _menu.ShowMainMenu();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _menu.StartGame();
        }
    }
}
