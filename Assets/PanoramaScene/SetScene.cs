using UnityEngine;

public class SetScene : MonoBehaviour
{
    Texture scene;
    string photo = PlayerPrefs.GetString("photo"); //Get the value of String photo. 
    // The String should come from the menu scene. After user chooses which scene he or she wants to play, the menu scene should set the value of String photo, which is the file name of the panorama photo, using PlayerPrefs.SetString
    void Start()
    {
        scene = (Texture2D)Resources.Load(photo); //Research the file named String photo in resources folder, set the Texture scene to the result file
        GetComponent<Renderer>().material.mainTexture = scene; //Set the texture of the panorama ball to Texture scene
    }
}
