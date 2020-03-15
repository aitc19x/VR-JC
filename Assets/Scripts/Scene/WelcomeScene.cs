using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScene : MonoBehaviour
{

    public void ShowMenu()
    {
        SceneManager.LoadScene("RoomSceneDemo");
    }

    public void ShowCopyright()
    {
        SceneManager.LoadScene("CopyrightScene");
    }
}
