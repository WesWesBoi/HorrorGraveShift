using UnityEngine;
using System.Collections.Generic;

public class Director : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public float intensity;
    public AnimationCurve intensityCurve;

    float maxTime = 30;
    float timer = 30;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        intensity = intensityCurve.Evaluate(timer / maxTime);

        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<StateMachineBehavior>().SetIntensity(intensity);
        }
    }
}
