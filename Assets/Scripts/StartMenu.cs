using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void ClickStart()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Reset()
    {
        SaveSystem.Reset();
    }

    public void RetureStart()
    {
        SceneManager.LoadScene("Start");
    }
}
