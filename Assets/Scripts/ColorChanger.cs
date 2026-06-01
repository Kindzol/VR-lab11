using UnityEngine;
using UnityEngine.InputSystem;

public class ColorChanger : MonoBehaviour
{
    [Header("Input")]
    public InputActionAsset inputActions;

    [Header("Object to color")]
    public GameObject targetObject;

    private InputAction primaryButtonAction;
    private Renderer targetRenderer;

    private Color[] colors = new Color[]
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow,
        Color.cyan
    };
    private int colorIndex = 0;

    void OnEnable()
    {
        var actionMap = inputActions.FindActionMap("XR actions");
        primaryButtonAction = actionMap.FindAction("primary buttons");
        primaryButtonAction.Enable();
        primaryButtonAction.performed += OnPrimaryButtonPressed;
    }

    void OnDisable()
    {
        primaryButtonAction.performed -= OnPrimaryButtonPressed;
        primaryButtonAction.Disable();
    }

    void Start()
    {
        targetRenderer = targetObject.GetComponent<Renderer>();
    }

    void OnPrimaryButtonPressed(InputAction.CallbackContext context)
    {
        colorIndex = (colorIndex + 1) % colors.Length;
        targetRenderer.material.color = colors[colorIndex];
    }
}