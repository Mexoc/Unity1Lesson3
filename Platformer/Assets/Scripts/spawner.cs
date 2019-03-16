using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] prefEnemy;
    public GameObject currentEnemy;
    private Random rnd;
    public List<GameObject> enemyList= new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {        
        CreateEnemy(prefEnemy[0]);
    }

    void CreateEnemy(GameObject Enemy)
    {
        currentEnemy = Instantiate(Enemy, transform.position, Quaternion.identity);
        enemyList.Add(currentEnemy);
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
            transform.position = new Vector2(gameObject.transform.position.x - Random.Range(-1f, 0f), 3.5f);
        }
    }
}
