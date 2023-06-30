using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] string interactButtonName;
    [SerializeField] LayerMask interactLayer;

    float nextInteractTime = 0.5f;


    void Update()
    {
        if (Input.GetButtonDown(interactButtonName) && Time.time >= nextInteractTime)
        {
            var result = Physics2D.OverlapCircle(transform.position, 1f, interactLayer);
            if (result != null)
            {
                if (result.TryGetComponent<IInteractable>(out var interactable))
                {
                    interactable.Interact();
                }
            }
        }
    }
}
