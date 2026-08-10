using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine.Events;

public class FruitManager : MonoBehaviour
{
    public List<GameObject> fruitsPrefabs;
    public float timer = 30f;
    public SpriteRenderer playerBasketSpriteRenderer;
    public List<GameObject> spawnedFruits;
    public float speed = 5f;
    public bool isCaught = false;
    public TMP_Text timerText;
    public GameObject rottenFruit;
    public bool caughtRottenFruitbool = false;
    public UnityEvent caughtRottenFruit;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //This will start both the coroutine to spawn the normal fruits and the rotten fruits
        StartCoroutine(fruitSpawner());
        StartCoroutine(rottenFruitSpawner());


    }

    // Update is called once per frame
    void Update()
    {
        //This will have the timer count down
        timer -= Time.deltaTime;

        //This will show the timer counting down up to 1 decimal point
        timerText.text = "Timer: " + timer.ToString("F1");

        if (timer <= 0f)
        {
            timer = 0;
        }



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

                //This bool will be able to have the points script track the fruit has been caught and then adding a point to the score
                isCaught = true;

                //This destroys the fruit when the player catches it
                Destroy(spawnedFruits[i]);

                //This removes the spawned fruit from the list as well to remove the error about getting a null reference
                spawnedFruits.Remove(spawnedFruits[i]);


                //This will check of the position of the spawned fruits is near the bounds to destroy the fruit and then it will destroy and remove the fruit form the list
            }
            else if (spawnedFruits[i].transform.position.y <= -5f)
            {
                //If the fruit isnt caught then just keep the bool false
                isCaught = false;

                //This destroys the fruit when the player catches it
                Destroy(spawnedFruits[i]);

                //This removes the spawned fruit from the list as well to remove the error about getting a null reference
                spawnedFruits.Remove(spawnedFruits[i]);

            }
        }
        {
        }
    }
    // This coroutine will spawn the fruits infinitly until the timer is 0
    IEnumerator fruitSpawner()
    {


        while (timer > 0)
        {
            //I created a variable to store the instantiate to be able to track the fruits that were spawned and to add them to the list of spawned fruits to have the player catch them.
            GameObject spawnedFruit = Instantiate(fruitsPrefabs[Random.Range(0, fruitsPrefabs.Count)], new Vector3(Random.Range(-4, 4), 6, 0), Quaternion.identity);

            //This adds the fruit that was spawned in the spawned fruits list 
            spawnedFruits.Add(spawnedFruit);

            //waits 2 seconds before spawning more fruits
            yield return new WaitForSeconds(1);
        }
    }

    //This is a coroutine only for the rotten fruit but same function as the list of fruits
    IEnumerator rottenFruitSpawner()
    {
        while (timer > 0)
        {
            //I created a variable to store the instantiate to be able to track the fruits that were spawned and to add them to the list of spawned fruits to have the player catch them.
            GameObject spawnedRottenFruit = Instantiate(rottenFruit, new Vector3(Random.Range(-4, 4), 6, 0), Quaternion.identity);

            //This while loop is running all the statements and such that were outside of the coroutine inside to be able to have reference to the spawned rotten fruits
            while (spawnedRottenFruit != null)
            {
                //This will move the spawned rotten fruit down the screen
                spawnedRottenFruit.transform.position -= Vector3.up * speed * Time.deltaTime;

                //this checks if the rotten fruit is caught by the player and then it will trigger the unity event and destroythe rotten fruit
                if (playerBasketSpriteRenderer.bounds.Contains(spawnedRottenFruit.transform.position) && !caughtRottenFruitbool)
                {

                    Debug.Log("Player had been slowed");

                    caughtRottenFruitbool = true;

                    //This will trigger the invoke event of slowing the player and losing 1 point for catching the rotten fruit
                    caughtRottenFruit.Invoke();

                    //This will destroy the rotten fruit after being caught
                    Destroy(spawnedRottenFruit);

                    //This will stop the nested while loop from looking at the one spawned rotten fruit
                    spawnedRottenFruit = null;

                    //This will make it so the UnityEvent is repeatable
                    caughtRottenFruitbool = false;

                }

                //Similar to the normal fruits it will destroy the rotten fruit after reaching the deadzone
                else if (spawnedRottenFruit.transform.position.y <= -5f)
                {
                    Destroy(spawnedRottenFruit);
                }

                yield return null;
            }
            //waits x seconds before spawning more fruits
            yield return new WaitForSeconds(0.5f);
        }


    }
}
