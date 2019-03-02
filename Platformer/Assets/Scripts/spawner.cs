using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] prefEnemy;
    public GameObject currentEnemy;
    private Random rnd;

    // Start is called before the first frame update
    void Start()
    {        
        CreateEnemy(prefEnemy[0]);
    }

    void CreateEnemy(GameObject Enemy)
    {
        currentEnemy = Instantiate(Enemy, transform.position, Quaternion.identity);
    }

    void Flip()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemy == null)
        {
            CreateEnemy(prefEnemy[0]);
            transform.position = new Vector2(Random.Range(-14f, 0f), 3.5f);
        }
    }
}
