using UnityEngine;
using UnityEngine.Events;

public class PlayerTriggerEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent onPlayerEnter = new UnityEvent();
    [SerializeField] private UnityEvent onPlayerExit = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            onPlayerEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            onPlayerExit.Invoke();
    }
}