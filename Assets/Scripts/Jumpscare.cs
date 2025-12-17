using System.Collections;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public GameObject jumpscareImg;
    public AudioSource audioSource;

    private bool isPlayed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpscareImg.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))

            if (!isPlayed)
        {
            jumpscareImg.SetActive(true);
            audioSource.Play();
            Coroutine coroutine = StartCoroutine(DisableImg());

                isPlayed = true;
        }
    }

    IEnumerator DisableImg()
    {
        yield return new WaitForSeconds(2f);
        jumpscareImg.SetActive(false);
    }
}

