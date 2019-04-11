using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public ScreenFadder fadder;

    public Button[] buttons;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 0);


        for (int i = 0; i < buttons.Length; i++)
        {
            if (i > levelReached)
                buttons[i].interactable = false;
        }   
    }

    public void Select(string Name)
    {
        fadder.FadeTo(Name);
    }

}
