using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer instance = null;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            print("Destroy on load");
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
