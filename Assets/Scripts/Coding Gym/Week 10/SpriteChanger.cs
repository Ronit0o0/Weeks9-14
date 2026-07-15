using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class SpriteChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public List<Sprite> sprites;
    public InputAction action;
    int i = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer.sprite = sprites[0];
        //this is also something new that allows me to choose a input for the context.performed to work
        action.AddBinding("<Keyboard>/space");
        //This allows the action to be performed when the input is detected
        action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite(InputAction.CallbackContext context)
    {
        //I found that .performed makes the code work when a button is pressed compared to the other methods
        if (context.performed)
        {
            Debug.Log("Space was pressed");
            i++;
            
         
            if (i >= sprites.Count)
            {
                i = 0;
                spriteRenderer.sprite = sprites[i];
            }

            spriteRenderer.sprite = sprites[i];
        }
    }
    
}
