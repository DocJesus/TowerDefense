using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public string menuName;

    public ScreenFadder fadder;
    public GameManager manager;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public void OnEnable()
    {
        if (levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }

    public void Continue()
    {
        fadder.FadeTo(nextLevel);
    }

    public void Menu()
    {
        Debug.Log("Menu");
        fadder.FadeTo(menuName);
    }
}
