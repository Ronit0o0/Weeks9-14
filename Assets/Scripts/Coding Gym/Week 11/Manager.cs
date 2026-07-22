using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Button playerAbutton;
    public Button playerBbutton;
    public GrowSprite PlayerA;
    public GrowSprite PlayerB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TakeTurns());
        playerBbutton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TakeTurns()
    {
        playerAbutton.interactable = true;

        yield return new WaitUntil(() => PlayerA.TurnIsOver);

        playerAbutton.interactable = false;

        playerBbutton.interactable = true;

        yield return new WaitUntil(() => PlayerB.TurnIsOver);

        playerBbutton.interactable = false;

    }
}
