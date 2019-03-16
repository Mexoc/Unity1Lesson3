using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    private GameObject _hero;
    private Collider2D _heroCollider;
    private Collider2D _collider;
    private Collision2D collision;

    // Start is called before the first frame update
    void Start()
    {        
        _hero = GameObject.FindGameObjectWithTag("hero");
        _heroCollider = _hero.GetComponent<BoxCollider2D>();
        _collider = gameObject.GetComponent<BoxCollider2D>();        
    }

    private void OnGUI()
    {                
        if (_collider.IsTouching(_heroCollider) && _hero.GetComponent<hero>().score >= 1000)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 100), "Level Complete");            
            SceneManager.LoadScene(0);
        }
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
