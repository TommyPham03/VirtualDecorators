using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class XRDeleteWhileGrabbed : MonoBehaviour
{
    public InputActionProperty deleteButton; 

    private InputAction _deleteAction;      
    private XRGrabInteractable grab;
    private bool isGrabbed = false;

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        _deleteAction = deleteButton.action.Clone();
    }

    void OnEnable()
    {
        _deleteAction.Enable();
        grab.selectEntered.AddListener(OnGrab);
        grab.selectExited.AddListener(OnRelease);
    }

    void OnDisable()
    {
        _deleteAction.Disable();
        grab.selectEntered.RemoveListener(OnGrab);
        grab.selectExited.RemoveListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)  => isGrabbed = true;
    void OnRelease(SelectExitEventArgs args) => isGrabbed = false;

    void Update()
    {
        if (isGrabbed && _deleteAction.WasPressedThisFrame())
        {
            Destroy(gameObject);
        }
    }
}