using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFireball : MonoBehaviour
{
    public int damage = 20;
    float speed = 0.2f;
    public int direction;
    public GameObject _enemy;
    Vector3 shootDirection;
    private CircleCollider2D heroCol;
    
    void Update()
    {        
        Vector3 sc;
        if (direction == -1)
        {
            shootDirection = new Vector3(-2, 0.2f);            
            transform.position += shootDirection * speed;
        }
        if (direction == 1)
        {
            //разворот спрайта
            sc = transform.localScale;
            sc.x *= -1;
            transform.localScale = sc;
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
        if (collision.gameObject.tag == "hero")
        {
            GameObject temp = collision.gameObject;
            heroCol = temp.GetComponent<CircleCollider2D>();
            temp.GetComponent<hero>().health -= damage;
            Destroy(gameObject);
        }
    }
}
