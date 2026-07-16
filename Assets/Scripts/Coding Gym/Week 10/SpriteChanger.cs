using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class SpriteChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public List<Sprite> sprites;
    int i = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer.sprite = sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite(InputAction.CallbackContext context)
    {
        Debug.Log("Button Pressed");
        //I found that .performed makes the code work when a button is pressed compared to the other methods
        if (context.started)
        {
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
