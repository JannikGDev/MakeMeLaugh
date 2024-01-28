using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartScene : MonoBehaviour
{
    public void X_RestartThisScene()
    {
        AudioManager.instance.OnRestart();
        Time.timeScale = 1;
        SceneManager.LoadScene("BuildScene");
    }
}
