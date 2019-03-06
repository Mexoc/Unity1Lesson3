using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    public GameObject _hero;
    private GUI ending;

    // Start is called before the first frame update
    void Start()
    {        
        _hero = GameObject.FindGameObjectWithTag("hero");
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hero")
        {
            GUI.Box(new Rect(200, 200, 100, 100), "Level Complete");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
