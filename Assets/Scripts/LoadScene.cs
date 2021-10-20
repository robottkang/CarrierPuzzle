using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public virtual void StageSceneLoder(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}