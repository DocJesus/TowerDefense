using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundsSurvived : MonoBehaviour
{
    public Text roundText;

    //parceque de base l'obj est désactivé donc quand il est activé cette fct est appelé
    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    //pour faire l'effet de décompte des waves
    IEnumerator AnimateText()
    {
        int i = 0;

        roundText.text = "0";

        yield return new WaitForSeconds(0.5f);

        while (i < PlayerStat.rounds)
        {
            i = i + 1;
            roundText.text = i.ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }

}
