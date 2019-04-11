using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenFadder : MonoBehaviour {

    public Image screenFadder;

    //courbe d'animation
    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadOut(scene));
    }

    //écran noir vers scene
    IEnumerator FadIn()
    {
        float t = 1f;

        while (t > 0)
        {
            t -= Time.deltaTime;

            //récupère la valeur de l'alpha par la courbe en fonctio de t
            float a = curve.Evaluate(t);

            //couleur noire
            screenFadder.color = new Color(0f, 0f, 0f, a);

            //skip une frame, permet de faire les chose petit à petit
            yield return 0;
        }
        
    }

    //scene vers écran noir
    IEnumerator FadOut(string _scene)
    {
        float t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime;

            //récupère la valeur de l'alpha par la courbe en fonctio de t
            float a = curve.Evaluate(t);

            //couleur noire
            screenFadder.color = new Color(0f, 0f, 0f, a);

            //skip une frame, permet de faire les chose petit à petit
            yield return 0;
        }

        // ne se lit que si le fondu est terminé
        SceneManager.LoadScene(_scene);

    }
}
