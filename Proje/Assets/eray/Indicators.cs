using UnityEngine;
using UnityEngine.UI;

public class Indicators : MonoBehaviour
{
    public static Indicators Instance { get; private set; }

    [SerializeField] private float maxCoal;
    [SerializeField] private float maxWood;

    private float currentCoal;
    private float currentWood;

    [SerializeField] private Slider lightSlider;
    [SerializeField] private Slider heightSlider;

    [SerializeField] private float lightPowerMultiplier = 1f;
    [SerializeField] private float heightDecreaseMultiplier = 1f;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        currentCoal = maxCoal;
        currentWood = maxWood;
    }

    public void UpdateSliders(float coal, float wood)
    {
        currentCoal += coal;
        currentWood += wood;

        if (currentCoal > 100 || currentCoal < 0)
            currentCoal = Mathf.Clamp(currentCoal, 0, 100);

        if (currentWood > 100 || currentWood < 0)
            currentWood = Mathf.Clamp(currentWood, 0, 100);

        lightSlider.value = currentCoal / maxCoal;
        heightSlider.value = currentWood / maxWood;
    }

    public float LightPower()
    {
        return currentCoal / maxCoal * lightPowerMultiplier;
    }

    public float HeightPower()
    {
        return currentWood / maxWood * heightDecreaseMultiplier;
    }
}