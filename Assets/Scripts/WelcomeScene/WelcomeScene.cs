﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScene : MonoBehaviour
{
    public GameObject SphereView;
    public Canvas MainCanvas, OptionsCanvas, CopyrightCanvas;

    public void Start() {
        InvokeRepeating("TurnBackground", 0.01f, 0.01f);
    }

    private void TurnBackground() {
        Material mat = SphereView.GetComponent<Renderer>().material;
        Vector2 vec = mat.GetTextureOffset("_MainTex");
        vec.x += 0.0001f;
        mat.SetTextureOffset("_MainTex", vec);
    }

    public void ShowMenu()
    {
        SceneManager.LoadScene("RoomSceneDemo");
    }

    public void ShowCopyright()
    {
        MainCanvas.gameObject.SetActive(false);
        CopyrightCanvas.gameObject.SetActive(true);
        OptionsCanvas.gameObject.SetActive(false);
    }

    public void ShowOptions() {
        MainCanvas.gameObject.SetActive(false);
        OptionsCanvas.gameObject.SetActive(true);
        CopyrightCanvas.gameObject.SetActive(false);
    }

    public void ShowMain() {
        CopyrightCanvas.gameObject.SetActive(false);
        OptionsCanvas.gameObject.SetActive(false);
        MainCanvas.gameObject.SetActive(true);
    }
}
