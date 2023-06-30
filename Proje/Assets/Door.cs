using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : MonoBehaviour
{
    public static Action OnDoorEntered;

    public bool isOpen = true;
    
    bool isDone;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isOpen && !isDone)
        {
            isDone = true;
            OnDoorEntered?.Invoke();
        }
    }
}
