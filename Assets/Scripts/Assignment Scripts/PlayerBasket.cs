
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBasket : MonoBehaviour
{
    //The speed at which the player will move at
    public float speed;
    //This is a public variable of the players x and y vectors and moves with player input only 
    private Vector2 playerMovement = Vector2.zero;
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
    
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        playerMovement = context.ReadValue<Vector2>();
    }
}
