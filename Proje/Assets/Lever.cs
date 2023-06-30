using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] Mechanic[] mechanics;
    [SerializeField] GameObject infoText;

    public Animator animator;
    bool set;

    float nextToggleTime;

    private void OnTriggerEnter2D(Collider2D other) {
        infoText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        infoText.SetActive(false);
    }

    public void Interact()
    {
        if (Time.time < nextToggleTime)
            return;

        nextToggleTime = Time.time + 0.6f;
        set = !set;
        if (animator)
            animator.SetBool("set", set);
        foreach (var mechanic in mechanics)
        {
            mechanic.Toggle();
        }    
    }
}
