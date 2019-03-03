using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newGUI : MonoBehaviour
{
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp;
        temp = GameObject.FindGameObjectWithTag("hero");
        health = temp.GetComponent<hero>().health;
    }

    private void OnGUI()
    {
            
    }

    // Update is called once per frame
    void Update()
    {

    }
}
