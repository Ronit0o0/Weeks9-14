using UnityEngine;

public class FruitMover : MonoBehaviour
{
    public float speed = 8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //This will have the fruits move down when spawned
        transform.position -= Vector3.up * Time.deltaTime;

        Destroy(gameObject, 5f);
    }
}
