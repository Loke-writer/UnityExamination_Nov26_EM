using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonHazards : MonoBehaviour
{
    private bool hasShield;
    private bool isRestarting;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Potion"))
            return;

        hasShield = true;
        other.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isRestarting || !collision.gameObject.CompareTag("SpikeTrap"))
            return;

        if (hasShield)
        {
            hasShield = false;
            return;
        }

        isRestarting = true;
        SceneManager.LoadScene(gameObject.scene.buildIndex);
    }
}