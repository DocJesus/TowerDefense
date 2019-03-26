using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour {

    public Text livesText;

	// Use this for initialization
	void Start ()
    {
        livesText = GetComponent<Text>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        livesText.text = PlayerStat.lives.ToString() + " HP";
	}
}
