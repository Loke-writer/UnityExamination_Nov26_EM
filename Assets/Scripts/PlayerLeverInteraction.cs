using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerLeverInteraction : MonoBehaviour
{
    [SerializeField] private Button leverButton;

    private bool leverInRange;

    public void SetLeverInRange(bool inRange)
    {
        leverInRange = inRange;
    }

    public void OnInteract(InputValue value)
    {
        Debug.Log($"Interact: pressed={value.isPressed}, in range={leverInRange}, button assigned={leverButton != null}");
        if (value.isPressed && leverInRange && leverButton != null)
        {
            leverButton.onClick.Invoke();
        }
    }
}