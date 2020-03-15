using UnityEngine;
using UnityEngine.SceneManagement;

public class CopyrightScene : MonoBehaviour
{
    public void BackToWelcome()
    {
        SceneManager.LoadScene("WelcomeScene");
    }
}
