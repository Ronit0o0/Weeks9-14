using UnityEngine;

public class HeartRate : MonoBehaviour
{
    public AnimationCurve animateCurve;
    public int speed = 5;
    public float startPosition;
    public float progress;
    public float duration;
    TrailRenderer trailRenderer;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        

        progress += Time.deltaTime;

        float yPosition = transform.position.y;

        yPosition = animateCurve.Evaluate(progress/duration);

        float xPosition = transform.position.x + speed * Time.deltaTime;

        


        Vector2 checkBounds = Camera.main.WorldToScreenPoint(new Vector2(xPosition, yPosition));


        if (checkBounds.x >= Screen.width - 10)
        {
            xPosition = startPosition;
            trailRenderer.emitting = false;

        }
        else
        {
            trailRenderer.emitting = true;
        }


            Vector3 heartRate = new Vector3(xPosition, yPosition, 0);

        transform.position = heartRate;
    }
}
