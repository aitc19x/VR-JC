using UnityEngine;
using UnityEngine.SceneManagement;

namespace WelcomeScene
{
    public class ButtonHandler : MonoBehaviour
    {
        public void ShowMenu()
        {
            SceneManager.LoadScene("MenuScene");
        }

        public void ShowCopyright()
        {
            SceneManager.LoadScene("CopyrightScene");
        }
        
        private static void KillScene(Scene scene, LoadSceneMode sceneMode){
            for (int i = 0; i < SceneManager.sceneCount; i++){
                if (SceneManager.GetSceneAt(i).name != (scene.name)) {
                    SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i));
                    break;
                }
            }
        }
    }
}
