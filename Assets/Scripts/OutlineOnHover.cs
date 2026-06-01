using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class OutlineOnHover : MonoBehaviour
{
    private Outline outline;
    private XRBaseInteractable interactable;

    void Start()
    {
  
        outline = GetComponent<Outline>();
        outline.enabled = false;
        interactable = GetComponent<XRBaseInteractable>();

        interactable.hoverEntered.AddListener(_ => outline.enabled = true);
        interactable.hoverExited.AddListener(_ => outline.enabled = false);
    }
}