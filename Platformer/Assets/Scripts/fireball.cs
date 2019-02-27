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

    // Update is called once per frame
    void Update()
    {
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
            temp.GetComponent<enemy>().health -= damage;
            Destroy(gameObject);
        }
    }
}
