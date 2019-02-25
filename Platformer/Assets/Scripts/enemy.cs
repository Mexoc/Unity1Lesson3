using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 100;
    private float speed = 2f;
    private int direction = -1;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(Time.deltaTime * speed * direction, 0);
        if (health <= 0 || gameObject.transform.position.y <= -6) Destroy(gameObject);  
    }

    
} 
