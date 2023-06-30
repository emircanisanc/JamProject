using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightUp : MonoBehaviour
{
    Indicators Indicator => Indicators.Instance;

    [SerializeField] private float defaultWood = -0.8f;
    [SerializeField] private float burningCoal = -2f;
    [SerializeField] private float burningWood = -0.2f;


    private Light2D light;

    private void Awake()
    {
        light = GetComponent<Light2D>();
    }

    private void Update()
    {
        Indicator.UpdateSliders(0, defaultWood * Time.deltaTime);
        if (!Input.GetKey(KeyCode.Space))
        {
            // SoundManager.Instance.StopSoundLoop();
            light.pointLightOuterRadius = 0.5f;
            light.pointLightInnerRadius = 0f;
            return;
        }

        light.pointLightOuterRadius = 1;
        light.pointLightInnerRadius = 0.5f * Indicators.Instance.LightPower();
        Indicator.UpdateSliders(burningCoal * Time.deltaTime, burningWood * Time.deltaTime);
        // SoundManager.Instance.PlaySoundLoop("Space");
    }
}