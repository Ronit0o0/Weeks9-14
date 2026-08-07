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
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(fruitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        //This will have the timer count down
        timer -= Time.deltaTime;

        //I need this for loop to have all the new and old fruits spawned moving down the screen or else the old fruits will get stuck and just stay there until the player catches a falling fruit
        for (int i = 0; i < spawnedFruits.Count; i++)
        {

        //This moves the spawned fruits down the screen  
        spawnedFruits[i].transform.position -= Vector3.up * speed * Time.deltaTime;

        //This line of code will check the bounds of the players basket if the spawned fruit is within its bounds to "catch" it then remove it from the scene 
        if (playerBasketSpriteRenderer.bounds.Contains(spawnedFruits[i].transform.position))
        {
            //This justchecks if the IF statement was working
            Debug.Log("Fruit Collected!");

            //This destroys the fruit when the player catches it
            Destroy(spawnedFruits[i]);

            //This removes the spawned fruit from the list as well to remove the error about getting a null reference
            spawnedFruits.Remove(spawnedFruits[i]);

        } else if (spawnedFruits[i].transform.position.y <= -5f)
        {
            //This destroys the fruit when the player catches it
            Destroy(spawnedFruits[i]);

            //This removes the spawned fruit from the list as well to remove the error about getting a null reference
            spawnedFruits.Remove(spawnedFruits[i]);
        }
        }

        
        {
            //This will remove the fruits from the scene and list if the player didn't catch it to not get a error
            
        }
    }
    // This coroutine will spawn the fruits infinitly until the timer is 0
    IEnumerator fruitSpawner()
    {
        
        
        while(timer > 0)
        {    
            //I created a variable to store the instantiate to be able to track the fruits that were spawned and to add them to the list of spawned fruits to have the player catch them.
            GameObject spawnedFruit = Instantiate(fruitsPrefabs[Random.Range(0, fruitsPrefabs.Count)],new Vector3(Random.Range(-4, 4), 6, 0), Quaternion.identity);

            //This adds the fruit that was spawned in the spawned fruits list 
            spawnedFruits.Add(spawnedFruit);

            //waits 2 seconds before spawning more fruits
            yield return new WaitForSeconds(2);
        }
        
    }
}
