using UnityEngine;

public class FlickeringLights : MonoBehaviour
{
    private Light light;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.5f;
    public float flickerSpeed = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light = GetComponent<Light>();
        InvokeRepeating("Flicker", 0f, flickerSpeed);
    }

    // Update is called once per frame
    private void Flicker ()
    {
        float randomIntensity = Random.Range(minIntensity, maxIntensity);
        light.intensity = randomIntensity;
    }
}
