using System.Collections;
using UnityEngine;
using System.Collections.Generic;



public class Grower : MonoBehaviour
{
    public AnimationCurve growthCurve;
    public float growthDuration;
    private float growthProgress = 0f;

    public List<GameObject> buildingParts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnBuilding());   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBuilding()
    { 
        

        for(int i = 0; i < buildingParts.Count; i++)
        {
            buildingParts[i].transform.localScale = Vector3.zero;

            while (growthProgress < growthDuration)
            {
                growthProgress += Time.deltaTime;
                buildingParts[i].transform.localScale = growthCurve.Evaluate(growthProgress / growthDuration) * Vector3.one;
                // Debug.Log(growthProgress);

                yield return null;
            }

            growthProgress = 0f;
        }  
    } 

    void ScaletheBuilding()
    {    
            StartCoroutine(SpawnBuilding());    
    }
}
