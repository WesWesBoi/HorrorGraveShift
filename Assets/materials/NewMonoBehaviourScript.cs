using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    MeshRenderer meshR;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshR.material.color = new Color(0, 0, 0, 225);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
