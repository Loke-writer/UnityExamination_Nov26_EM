using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMenu : MonoBehaviour
{
    public void EnterDungeon()
    {
        SceneManager.LoadScene("Dungeon");
    }

    public void OpenScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}