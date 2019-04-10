using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject UI;
    public ScreenFadder fadder;
    public string MenuName = "MainMenu";

	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggel();
        }
	}

    public void Toggel()
    {
        UI.SetActive(!UI.activeSelf);

        if (UI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggel();
        //on recharge la scenen actuel
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        fadder.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Debug.Log("MainMenu");
        //charge une scene avec un fadder
        Toggel();
        fadder.FadeTo(MenuName);
    }
}
