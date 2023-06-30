using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPowerUp : PowerUp
{
    public override void Collect()
    {
        Indicators.Instance.UpdateSliders(0, 10f);
        base.Collect();
    }
}