using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ShellReset : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Transform originalParent;
    private XRGrabInteractable grab;

    void Awake()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        originalParent = transform.parent;
        grab = GetComponent<XRGrabInteractable>();
    }

    void OnEnable()
    {
        ResetShell();
    }

    public void ResetShell()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        transform.SetParent(originalParent);

        if (grab != null)
            grab.enabled = true;
    }
}