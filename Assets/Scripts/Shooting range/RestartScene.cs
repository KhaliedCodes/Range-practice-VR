using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
