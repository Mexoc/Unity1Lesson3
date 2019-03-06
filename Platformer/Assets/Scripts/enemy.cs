using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 100;
    private float speed = 1f;
    public int direction;
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
    public GameObject enemyFireball;
    public bool shoot;
    public bool Right;
    public int enemyFireballDirection;
    int counter;

    private void Start()
    {
        patrol = true;
        mask = 9;
        Y = -1;
        X = -1;
        direction = -1;
        shoot = false;
        Right = false;
    }

    private void Move()
    {
        gameObject.transform.position += new Vector3(Time.deltaTime * speed * direction, 0);
    }

    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(gameObject.transform.position, new Vector2(X, Y), 4, mask);
        Debug.DrawRay(gameObject.transform.position, new Vector2(X, Y), Color.blue);
        Debug.Log(ray.collider);
        if (patrol)
        {
            if (ray.collider)
            {
                Move();
            }
            else
            {
                Flip();
            }
        }
        else
        {
            Y = 0;
            if (ray.collider)
            {
                if (shoot == false && ray.collider.tag == "hero")
                {
                    shoot = true;
                    StartCoroutine(EnemyShoot());
                }
            }
        }
    }

    void Flip()
    {
        Right = !Right;
        Vector2 sc = transform.localScale;
        sc.x *= -1;
        transform.localScale = sc;
        X *= -1;
        direction *= -1;
    }

    IEnumerator EnemyShoot()
    {

        for (int i = 0; i < 10; i++)
        {
            Instantiate(enemyFireball, gameObject.transform.position, Quaternion.identity);
            enemyFireball.name = "enemyFireball";
            enemyFireball.GetComponent<enemyFireball>().direction = enemyFireballDirection;
            yield return new WaitForSeconds(1);
        }
        shoot = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _hero = GameObject.FindGameObjectWithTag("hero");
        enemyPos = gameObject.transform.position;
        heroPos = _hero.GetComponent<Transform>().position;
        if (collision.gameObject.tag == "hero")
        {
            if (enemyPos.x >= heroPos.x && Right)
            {
                Flip();
                enemyFireballDirection = -1;
            }
            if (enemyPos.x <= heroPos.x && !Right)
            {
                Flip();
                enemyFireballDirection = 1;
            }
            patrol = false;
            angry = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
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
