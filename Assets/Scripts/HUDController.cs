using UnityEngine;
using TMPro;
using System;

public class HUDController : MonoBehaviour
{
    public static HUDController instance;
    private void Awake()
    {
        instance = this;
        
    }
    [SerializeField] TMP_Text interactionText;

    void EnableInteractionText(string text)
    {
        interactionText.text = text + "(F)";
        interactionText.gameObject.SetActive(true);
    }
    void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }

    internal void EnableInteractionText(string message)
    {
        throw new NotImplementedException();
    }
}
