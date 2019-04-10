using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool gameIsOver;

    public GameObject gameOverUI;
    public GameObject pauseUI;
    public GameObject winUI;

    public ScreenFadder fadder;


    private void Start()
    {
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.L))
            EndGame();

        if (gameIsOver)
            return;

	    if (PlayerStat.lives <= 0)
        {
            EndGame();
        }
	}

    void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        winUI.SetActive(true);
        gameIsOver = true;
    }
}
