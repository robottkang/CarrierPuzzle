using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public bool isDontDestroyOnLoad = false;
    public string dontDestroyOnLoadObject;
    public virtual void StageSceneLoder(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        if(isDontDestroyOnLoad)
        {
            DontDestroyOnLoad(GameObject.Find(dontDestroyOnLoadObject));
        }
    }
}