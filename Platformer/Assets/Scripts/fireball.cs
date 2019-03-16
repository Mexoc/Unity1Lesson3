using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public int damage = 20;
    float speed = 0.2f;
    public int direction = 1;
    Vector3 shootDirection;
    public GameObject _right;
    private CircleCollider2D enemyCol;
    //private GameObject _enemy;
    private GameObject[] _enemy;
    private GameObject _hero;
    private GameObject[] _spawner;

    private void Start()
    {
        //_enemy = GameObject.FindGameObjectWithTag("enemy");
        _enemy = GameObject.FindGameObjectsWithTag("enemy");
        _hero = GameObject.FindGameObjectWithTag("hero");
    }

    // Update is called once per frame
    void Update()
    {
        _enemy = GameObject.FindGameObjectsWithTag("enemy");
        //flip = gameObject.GetComponent<SpriteRenderer>().flipY;
        if (direction == -1)
        {
            shootDirection = new Vector3(- 2, 0.2f);                  
            transform.position += shootDirection * speed;
        }
        if (direction == 1)
        {
            shootDirection = new Vector3(2, 0.2f);
            transform.position += shootDirection * speed;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            GameObject temp = collision.gameObject;
            enemyCol = temp.GetComponent<CircleCollider2D>();
            temp.GetComponent<enemy>().health -= damage;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "platform" || collision.gameObject.tag == "sword")
            Destroy(gameObject);

        //обновление счёта при уничтожении врага
        
        //if (collision.gameObject.tag == "enemy" && _enemy.GetComponent<enemy>().health == 0)
        //{
        //    _hero.GetComponent<hero>().score += 100;
        //}  
        for (int i = 0; i < _enemy.Length; i++)
        {
            if (collision.gameObject.tag == "enemy" && _enemy[i].GetComponent<enemy>().health == 0)
            {
                _hero.GetComponent<hero>().score += 100;
            } 
        }
    }
}
