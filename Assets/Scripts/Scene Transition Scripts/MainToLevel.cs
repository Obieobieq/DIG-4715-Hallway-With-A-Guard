using UnityEngine;
using UnityEngine.SceneManagement;

public class MainToLevel : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene("Level");
    }
}
