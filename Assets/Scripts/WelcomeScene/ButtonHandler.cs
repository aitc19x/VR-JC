using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WelcomeScene
{
    public class ButtonHandler : MonoBehaviour
    {
        private void SaveCamera()
        {
            if (Camera.main == null) return;
            var rotation = Camera.main.transform.rotation;
            PlayerPrefs.SetFloat("camera_rot_x", rotation.x);
            PlayerPrefs.SetFloat("camera_rot_y", rotation.y);
            PlayerPrefs.SetFloat("camera_rot_z", rotation.z);
            PlayerPrefs.SetFloat("camera_rot_w", rotation.w);
            var position = Camera.main.transform.position;
            PlayerPrefs.SetFloat("camera_pos_x", position.x);
            PlayerPrefs.SetFloat("camera_pos_y", position.y);
            PlayerPrefs.SetFloat("camera_pos_z", position.z);
        }

        public void ShowMenu()
        {
            SaveCamera();
            SceneManager.LoadScene("RoomSceneDemo");
        }

        public void ShowCopyright()
        {
            SaveCamera();
            SceneManager.LoadScene("CopyrightScene");
        }
    }
}
