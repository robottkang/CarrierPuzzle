using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButtonScript : MonoBehaviour
{
    public void GameQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
