using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FruitManager : MonoBehaviour
{
    public List<GameObject> fruitsPrefabs;
    public float timer = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // This coroutine will spawn the fruits infinitly until the timer is 0
    IEnumerator fruitSpawner()
    {
        timer -= Time.deltaTime;
        while(timer > 0)
        {
            Instantiate(fruitsPrefabs[Random.Range(0, fruitsPrefabs.Count)],new Vector3(Random.Range(-4, 4), 5, 0), Quaternion.identity);
        }
        yield return null;
    }
}
