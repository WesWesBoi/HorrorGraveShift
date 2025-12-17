using System;
using UnityEngine;

public class interactionss : MonoBehaviour
{
    public float playerReach = 3f;
    interact currentInteractable;

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
           
            
                currentInteractable.Interact();
            
        }
    }

    private void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.collider.tag == "Interactable")
            {
                interact newinteractable = hit.collider.GetComponent<interact>();
                if (currentInteractable && newinteractable != currentInteractable)
                {
                    DisableCurrentInteractable();
                }
                if (newinteractable.enabled)
                {
                    currentInteractable = newinteractable;
                    
                }
                  else
                {
                    DisableCurrentInteractable();
                }

            }
            else
            {
                DisableCurrentInteractable();
            }
            
           
        }
    }
    void SetNewCurrentInteractable(interact newinteractable)
    {
        currentInteractable = newinteractable;
        HUDController.instance.EnableInteractionText(currentInteractable.message);
    }
    void DisableCurrentInteractable()
    {
       
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;

        }
           
    }
}
