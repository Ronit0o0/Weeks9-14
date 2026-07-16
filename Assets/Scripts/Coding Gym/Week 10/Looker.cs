using UnityEngine;
using UnityEngine.InputSystem;

public class Looker : MonoBehaviour
{
    public Transform target;
    public Vector2 targetPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ONLY UPDATE TO FACE THE TARGET
        //WHEN THE MOUSE IS CLICKED:

        //bool isLeftKeyPressed = Keyboard.current.leftArrowKey.isPressed;

        bool leftMouseIsPressed = Mouse.current.leftButton.isPressed;
        bool leftMouseWasPressed = Mouse.current.leftButton.wasPressedThisFrame;
        bool leftMouseWasReleased = Mouse.current.leftButton.wasReleasedThisFrame;

        // Debug.Log(leftMouseWasReleased);

        // if(leftMouseWasPressed)
        // {
           
        // }


    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        targetPosition = Camera.main.ScreenToWorldPoint(context.action.ReadValue<Vector2>());

            Vector3 directionToTarget = (Vector3)targetPosition - transform.position;
            transform.up = directionToTarget;
    }
}



