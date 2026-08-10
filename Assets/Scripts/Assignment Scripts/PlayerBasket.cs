using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System.Security.Cryptography.X509Certificates;
public class PlayerBasket : MonoBehaviour
{
    //The speed at which the player will move at
    public float speed = 5;
    //This is a public variable of the players x and y vectors and moves with player input only 
    private Vector2 playerMovement = Vector2.zero;
    //These variables are for the dash 
    private float dashSpeed = 8;
    private float dashDuration = 0.5f;
    private bool isDashing = false;
    public float timerGoalSlow = 2f;
    public float timer;
    public ScoreSystem scoreSystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //create variables that are floats to then convert them into a vector 2 in order for it to work for the syntax with transform.position
        Vector2 playerMoving = new Vector2(playerMovement.x, 0);

        //This moves the player in either direction with WASD and the variable
        transform.position += (Vector3)playerMoving * speed * Time.deltaTime;

        //This will be the boundries on how far the player can move to the left and right of the screen
        //This will make it so the player wont move past the threshold and will just stay at the Max x position for either left or rightof the screen
        if (transform.position.x < -4)
        {
            transform.position = new Vector3(-4, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 4)
        {
            transform.position = new Vector3(4, transform.position.y, transform.position.z);
        }

    }
    //This will read the input from the player and will allow them to move left and right
    public void OnMove(InputAction.CallbackContext context)
    {
        playerMovement = context.ReadValue<Vector2>();
    }

    //This function will allow the player to dash to a fruit and will increase their speed when the input is click and when released it will go back to the original speed
    public void OnDash(InputAction.CallbackContext context)
    {
        //This checks the bool within the Coroutine to see if the player is dashing or not and if the input was pressed then to start the Coroutine
        if (context.performed && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    //This coroutiune allows my dash logic to work by having the player dash and then changing the speed to the original speed after the dash duration is over
    // Reference Video: https://www.youtube.com/watch?v=KQGo-Am1DaA
    IEnumerator Dash()
    {
        //This will set the bool to true for the dashing to be tracked by if statement
        isDashing = true;

        //Then set the speed to the dashing speed
        speed = dashSpeed;

        //Wait a bit before returning to normal speed
        yield return new WaitForSeconds(dashDuration);

        //Return Speed to original value
        speed = 5;

        //Make dashing false to slow speed to normal
        isDashing = false;
    }

    public void OnSlow()
    {
        //When the function is called with unity events it will take 1 point away from the player and start coroutine to slow the player
        scoreSystem.score -= 1;
        StartCoroutine(SlowPlayer());
    }

    IEnumerator SlowPlayer()
    {
        //This will set the player speed to 2
        speed = 2f;

        //Have the player slowed for 2 seconds
        yield return new WaitForSeconds(2f);

        //Then return the player speed to normal
        speed = 5f;
    }
}
