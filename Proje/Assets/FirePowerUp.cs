using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePowerUp : PowerUp
{
    public override void Collect()
    {
        // ADD FIRE
        Indicators.Instance.UpdateSliders(10f, 0);
        base.Collect();
    }
}