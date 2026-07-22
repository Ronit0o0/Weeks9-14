using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public Camera gameCamera;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentMousePosition = Mouse.current.position.ReadValue();

        Vector3 worldMousePosition = gameCamera.ScreenToWorldPoint(currentMousePosition);

        worldMousePosition.z = 0f;

        bool leftMouseIsPressed = Mouse.current.leftButton.wasPressedThisFrame;

        
        if (leftMouseIsPressed)
        {
            Instantiate(prefab, worldMousePosition, Quaternion.identity);
        }
        
        // Debug.Log(prefab);

           
        
    }

    

}
