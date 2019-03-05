using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newGUI : MonoBehaviour
{
    public int health;
    private Camera cam;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("hero");
        health = player.GetComponent<hero>().health;
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
