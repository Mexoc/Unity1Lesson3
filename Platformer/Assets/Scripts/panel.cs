using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel : MonoBehaviour
{
    public Transform[] Lives = new Transform[3];
    public GameObject _hero;
    public int heroLives;
    public int currentLife;
    
    void Start()
    {
        _hero = GameObject.FindGameObjectWithTag("hero");        
        for (int i = 0; i < Lives.Length; i++)
        {
            Lives[i] = transform.GetChild(i);
        }           
    }

    public void LivesMinus()
    {
        heroLives = _hero.GetComponent<hero>().Lives;
        for (int i = 0; i < Lives.Length; i++)
        {
            if (heroLives <= i)           
            {                
                Lives[i].gameObject.SetActive(false);             
            }     
            else Lives[i].gameObject.SetActive(true);
        }
    }

    void Update()
    {
        
    }
}
