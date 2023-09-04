using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
  

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
    
}
