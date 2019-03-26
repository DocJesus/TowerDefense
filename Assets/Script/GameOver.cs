using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Text roundText;
    //public Animator anim;

    //parceque de base l'obj est désactivé donc quand il est activé cette fct est appelé
    private void OnEnable()
    {
        //anim.SetTrigger("GameOver");
        roundText.text = PlayerStat.rounds.ToString();
    }

    public void Retry()
    {
        //charge la scene active
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Menu");
    }
}
