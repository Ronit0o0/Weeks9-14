using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GrowSprite : MonoBehaviour
{
    public AnimationCurve growthCurve;
    public float growthDuration;
    private float growthProgress = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private IEnumerator SpriteGrower()
    {
        while (growthProgress < growthDuration)
        {
            growthProgress += Time.deltaTime;
            transform.localScale = growthCurve.Evaluate(growthProgress / growthDuration) * Vector3.one;
            Debug.Log(growthProgress);
        }
        yield return null;
    }

    public void StartGrowth()
    {
        StartCoroutine(SpriteGrower());
    }
        
}
