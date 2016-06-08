using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public string Scene;

    public void Load()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene);
    }
}
