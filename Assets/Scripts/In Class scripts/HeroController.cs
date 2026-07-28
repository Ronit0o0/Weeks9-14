using UnityEngine;

public class HeroController : MonoBehaviour
{
    public Animator heroAnimator;
    public bool isMoving = false;
    public AudioSource footstep;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        heroAnimator.SetBool("IsMoving", isMoving);
    }

    public void OnFootstep()
    {
        footstep.Play();
    }

}
