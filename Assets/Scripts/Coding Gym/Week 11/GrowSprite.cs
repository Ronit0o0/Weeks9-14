using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GrowSprite : MonoBehaviour
{
    public AnimationCurve growthCurve;
    public float growthDuration;
    private float growthProgress = 0f;
    public Button startButton;
    public bool TurnIsOver = false;
    bool hasCoroutineStarted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      Debug.Log(startButton.interactable);

    }

    public IEnumerator SpriteGrower()
    {
        startButton.interactable = false;

        while (growthProgress < growthDuration)
        {
            growthProgress += Time.deltaTime;
            transform.localScale = growthCurve.Evaluate(growthProgress / growthDuration) * Vector3.one;
            Debug.Log(growthProgress);

            yield return null;
        }
        TurnIsOver = true;
        startButton.interactable = true;
    }

    public void StartGrowth()
    {
        TurnIsOver = false;
        StartCoroutine(SpriteGrower());
        
    }
        
}
 