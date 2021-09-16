using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void StageSceneLoder(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
