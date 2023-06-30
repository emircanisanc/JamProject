using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour, IDamageable
{
    public static Action OnPlayerDie;

    bool isAlive = true;

    public void ApplyDamage()
    {
        if (isAlive)
        {
            isAlive = false;
            OnPlayerDie?.Invoke();
        }
    }
}
