using UnityEngine;

public class RunePickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInParent<PlayerMovement>() != null)
        {
            gameObject.SetActive(false);
        }
    }
}