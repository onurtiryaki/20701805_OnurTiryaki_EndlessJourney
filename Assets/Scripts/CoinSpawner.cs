using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    //[SerializeField] private GameObject barrierPrefab;
    private GameObject newCoin;
    //private GameObject newBarrier;

    [SerializeField] private float x;

    [SerializeField] private float goldTime;
    private float goldCurrentTime;


    //[SerializeField] private float barrierTime;
    //private float barrierCurrentTime;

    private void Update()
    {
        transform.Translate(Vector3.forward * 10 * Time.deltaTime);


        if(goldCurrentTime < 0)
        {
            goldCurrentTime = goldTime;
            newCoin = Instantiate(coinPrefab, new Vector3(Random.Range(-x, x), coinPrefab.transform.position.y, transform.position.z), Quaternion.identity);
        }
        else
        {
            goldCurrentTime -= Time.deltaTime;
        }



        /*if(barrierCurrentTime < 0)
        {
            barrierCurrentTime = barrierTime;
            newBarrier = Instantiate(barrierPrefab, new Vector3(Random.Range(-x, x), barrierPrefab.transform.position.y, transform.position.z), Quaternion.identity);
        }
        else
        {
            barrierCurrentTime -= Time.deltaTime;
        }
        */
    }
}
