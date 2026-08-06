using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.Contracts;

public class FruitManager : MonoBehaviour
{
    public List<GameObject> fruitsPrefabs;
    public float timer = 30f;
    public SpriteRenderer playerBasketSpriteRenderer;
    public List<GameObject> spawnedFruits;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(fruitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        //This line of code will check the bounds of the players basket if the spawned fruit is within its bounds to "catch" it then remove it from the scene 
        if (playerBasketSpriteRenderer.bounds.Contains(spawnedFruits[spawnedFruits.Count - 1].transform.position))
        {
            //This justchecks if the IF statement was working
            Debug.Log("Fruit Collected!");

            //This destroys the fruit when the player catches it
            SetActive(spawnedFruits[spawnedFruits.Count - 1]);

            //This removes the spawned fruit from the list as well to remove the error about getting a null reference
            spawnedFruits.Remove(spawnedFruits[spawnedFruits.Count - 1]);
            
        }
    }
    // This coroutine will spawn the fruits infinitly until the timer is 0
    IEnumerator fruitSpawner()
    {
        
        
        while(timer > 0)
        {    
            // I created a variable to store the instantiate to be able to track the fruits that were spawned and to add them to the list of spawned fruits to have the player catch them.
            GameObject spawnedFruit = Instantiate(fruitsPrefabs[Random.Range(0, fruitsPrefabs.Count)],new Vector3(Random.Range(-4, 4), 5, 0), Quaternion.identity);

            //This adds the fruit that was spawned in the spawned fruits list 
            spawnedFruits.Add(spawnedFruit);

            //waits 2 seconds before spawning more fruits
            yield return new WaitForSeconds(2);
        }
        
    }
}
