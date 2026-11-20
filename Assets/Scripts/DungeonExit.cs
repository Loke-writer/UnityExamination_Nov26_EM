using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonExit : MonoBehaviour
{
    [SerializeField] private RunePickup[] runes = new RunePickup[3];
    [SerializeField] private TMP_Text objectiveText;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private string nextSceneName;
    private bool loadingNextScene;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!enabled || victoryPanel == null || runes.Length != 3)
            return;

        foreach (RunePickup rune in runes)
        {
            if (rune == null || rune.gameObject.activeSelf)
                return;
        }

        Rigidbody2D playerBody = other.attachedRigidbody;
        if (playerBody == null ||
            !playerBody.TryGetComponent(out PlayerMovement movement))
            return;
        if (!string.IsNullOrWhiteSpace(nextSceneName))
        {
            loadingNextScene = true;
            SceneManager.LoadScene(nextSceneName);
            return;
        }

        enabled = false;
        movement.enabled = false;
        playerBody.simulated = false;

        if (objectiveText != null)
            objectiveText.gameObject.SetActive(false);

        victoryPanel.SetActive(true);
    }
}