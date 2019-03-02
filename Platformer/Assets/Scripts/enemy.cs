using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 100;
    private float speed = 2f;
    private int direction = -1;
    private Vector3 enemyPos;
    private Vector3 heroPos;
    private bool enemyFlip;
    private GameObject _hero;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        _hero = GameObject.FindGameObjectWithTag("hero");
        enemyPos = gameObject.transform.position;
        heroPos = _hero.GetComponent<Transform>().position;
        if (collision.gameObject.tag == "hero")
        {
            if (enemyPos.x >= heroPos.x)
            {
                direction = -1;
                GetComponent<SpriteRenderer>().flipX = true;
            }            
            else
            {
                direction = 1;
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(Time.deltaTime * speed * direction, 0);
        if (health <= 0 || gameObject.transform.position.y <= -6) Destroy(gameObject);      
    }    
} 
