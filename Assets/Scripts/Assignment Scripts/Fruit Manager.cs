using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FruitManager : MonoBehaviour
{
    public List<GameObject> fruitsPrefabs;
    public float timer = 30f;
    public float dropSpeed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(fruitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        fruitsPrefabs[0].transform.position += Vector3.up * dropSpeed * Time.deltaTime;
    }
    // This coroutine will spawn the fruits infinitly until the timer is 0
    IEnumerator fruitSpawner()
    {
        
        
        while(timer > 0)
        {    
             
            Instantiate(fruitsPrefabs[Random.Range(0, fruitsPrefabs.Count)],new Vector3(Random.Range(-4, 4), 5, 0), Quaternion.identity);

            yield return new WaitForSeconds(5);
        }
        
    }
}
