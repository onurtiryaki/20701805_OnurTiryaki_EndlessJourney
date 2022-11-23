using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstraclePrefab;
    public float spawnTime=1;
    private float timer = 0; 
 

    // Update is called once per frame
    void Update()
    {
        if (timer>spawnTime)
        {
            int rand = Random.Range(0,obstraclePrefab.Length);
            GameObject obj = Instantiate(obstraclePrefab[rand]);
            obj.transform.position = transform.position + new Vector3(-2, 2, 0);
            timer = 0;

        }

        timer += Time.deltaTime;
    }
}
