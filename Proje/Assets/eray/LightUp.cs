using UnityEngine;

public class LightUp : MonoBehaviour
{
    Indicators Indicator => Indicators.Instance;

    [SerializeField] private float defaultWood = -0.8f;
    [SerializeField] private float burningCoal = -2f;
    [SerializeField] private float burningWood = -0.2f;


    private void Update()
    {
        Indicator.UpdateSliders(0, defaultWood * Time.deltaTime);
        if (!Input.GetKey(KeyCode.Space))
        {
            SoundManager.Instance.StopSoundLoop();
            return;
        }

        // increase light power
        Indicator.UpdateSliders(burningCoal * Time.deltaTime, burningWood * Time.deltaTime);
        SoundManager.Instance.PlaySoundLoop("Space");
    }
}