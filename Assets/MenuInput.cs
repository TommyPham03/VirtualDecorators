using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInput : MonoBehaviour
{
    [Header("UI")]
    public Canvas menuCanvas;

    [Header("Input Action")]
    public InputActionReference menuToggleAction;

    private bool menuOpen = false;

    void OnEnable()
    {
        if (menuToggleAction != null)
            menuToggleAction.action.performed += ToggleMenu;
    }

    void OnDisable()
    {
        if (menuToggleAction != null)
            menuToggleAction.action.performed -= ToggleMenu;
    }

    private void ToggleMenu(InputAction.CallbackContext ctx)
    {
        menuOpen = !menuOpen;
        menuCanvas.enabled = menuOpen;
    }
}
