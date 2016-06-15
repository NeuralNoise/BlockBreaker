using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string level)
    {
        Brick.breakableCount = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }

    public void LoadNextLevel()
    {
        Brick.breakableCount = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BrickDestroyed()
    {
        bool lastBrickDestroyed = Brick.breakableCount <= 0;
        if(lastBrickDestroyed)
        {
            LoadNextLevel();
        }
    }
}
