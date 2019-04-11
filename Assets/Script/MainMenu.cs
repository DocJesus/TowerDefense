using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string levelToLoad = "SampleScene";
    public ScreenFadder fadder;

	public void Play()
    {
        Debug.Log("play");
        fadder.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
