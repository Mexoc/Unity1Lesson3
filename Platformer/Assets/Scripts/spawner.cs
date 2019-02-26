using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] prefEnemy;
    public GameObject currentEnemy;

    // Start is called before the first frame update
    void Start()
    {
        CreateEnemy(prefEnemy[0]);
    }

    void CreateEnemy(GameObject Enemy)
    {
        currentEnemy = Instantiate(Enemy, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemy == null)
            CreateEnemy(prefEnemy[0]);
    }
}
