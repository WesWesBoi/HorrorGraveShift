using System;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public GameObject money,intText;
    public AudioSource open, close;
    public bool opened;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (opened == false)
            {
                intText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    money.SetActive(false);
                   
                    intText.SetActive(false);
                    //open.Play();
                    StartCoroutine(InvokeRepeating());
                    opened = true;
                }
            }
        }
    }

    private string InvokeRepeating()
    {
        throw new NotImplementedException();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
        }
    }
}
