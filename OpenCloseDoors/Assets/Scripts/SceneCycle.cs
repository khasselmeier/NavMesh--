using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCycle : MonoBehaviour
{
    public void SwitchToDevScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        SceneManager.LoadScene(nextSceneIndex);
    }

    public void SwitchToProdScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 2;

        SceneManager.LoadScene(nextSceneIndex);
    }
}