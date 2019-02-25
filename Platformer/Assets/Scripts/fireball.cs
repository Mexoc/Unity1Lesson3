using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public int damage = 20;
    float speed = 0.5f;
    public int direction = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right*speed*direction;
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
