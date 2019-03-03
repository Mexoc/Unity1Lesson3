using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 100;
    private float speed = 1f;
    private int direction;
    private Vector3 enemyPos;
    private Vector3 heroPos;
    private bool enemyFlip;
    private GameObject _hero;
    private Collider bulletCol;
    public bool patrol;
    public bool angry;
    public int X;
    public int Y;
    public LayerMask mask;

    private void Start()
    {
        patrol = true;
        mask = 9;
        Y = -1;
        X = -1;
        direction = -1;
    }    

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

    private void Move()
    {
        gameObject.transform.position += new Vector3(Time.deltaTime * speed * direction, 0);        
    }

    private void FixedUpdate()
    {        
        RaycastHit2D ray = Physics2D.Raycast(gameObject.transform.position, new Vector2(X, Y), 4, mask);
        Debug.DrawRay(gameObject.transform.position, new Vector2(X, Y), Color.blue, 10);
        Debug.Log(ray.collider);
        if (patrol)
        {                        
            if (ray.collider)
            {
                if (X == 1) GetComponent<SpriteRenderer>().flipX = false;
                else GetComponent<SpriteRenderer>().flipX = true;
                Move();
            }
            else
            {
                X *= -1;
                direction *= -1;
                Move();
            }
        }
        else
        {
            Y = 0;
        }
        
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hero")
        {
            patrol = false;
            angry = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hero")
        {
            patrol = true;
            angry = false;
            Y = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 || gameObject.transform.position.y <= -6) Destroy(gameObject);         
    }    
} 
