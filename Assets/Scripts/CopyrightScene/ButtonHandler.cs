using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{

    public void Start()
    {
        
        Camera.main.transform.SetPositionAndRotation(new Vector3(PlayerPrefs.GetFloat("camera_pos_x"), PlayerPrefs.GetFloat("camera_pos_y"), PlayerPrefs.GetFloat("camera_pos_z")), new Quaternion(PlayerPrefs.GetFloat("camera_rot_x"), PlayerPrefs.GetFloat("camera_rot_y"), PlayerPrefs.GetFloat("camera_rot_z"), PlayerPrefs.GetFloat("camera_rot_w")));
    }

    public void BackToWelcome()
    {
        SceneManager.LoadScene("WelcomeScene");
    }
}
