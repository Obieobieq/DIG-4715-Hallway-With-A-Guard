using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMenu : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene("Menu");
    }
}
