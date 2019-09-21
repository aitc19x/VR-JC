using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("WelcomeScene", LoadSceneMode.Additive);
    }
}
