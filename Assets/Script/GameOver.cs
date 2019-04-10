using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    //public Animator anim;

    public string menuName;

    public ScreenFadder fadder;

    public void Retry()
    {
        //charge la scene active
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        fadder.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Debug.Log("Menu");
        fadder.FadeTo(menuName);
    }
}
