using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class interact : MonoBehaviour
{
    Outline outline;
    public string message;

    public UnityEvent onInteraction;
    public static HUDController instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Interact()
    {
        onInteraction.Invoke();

    }
   
}
