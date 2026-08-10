using UnityEngine;
using TMPro;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.Events;

public class ScoreSystem : MonoBehaviour
{
    public FruitManager fruitManager;
    public int score = 0;
    public TMP_Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //This will display the current score 
        scoreText.text = "Score: " + score.ToString();

        //This will check if the player caught the fruit and then will add 1 point to the score
        if (fruitManager.isCaught == true)
        {
            //The score will increase by 1 and add onto the score text
            score += 1;

            //This will make the bool false in order for the score to not go up by 1 everyframe
            fruitManager.isCaught = false;
        }
    }


}
