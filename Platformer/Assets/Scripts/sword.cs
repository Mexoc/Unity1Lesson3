using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    private Collision2D enemyCollision;
    private Collision2D heroCollision;
    private int damage = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            GameObject temp = collision.gameObject;
            temp.GetComponent<enemy>().health -= damage;
        }
        else if (collision.gameObject.tag == "hero")
        {
            GameObject temp = collision.gameObject;
            temp.GetComponent<hero>().health -= damage;
        }
    }
}
