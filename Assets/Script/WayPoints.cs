using UnityEngine;

public class WayPoints : MonoBehaviour {

    public static Transform[] points;

    private void Awake()
    {
        //fait un array de la taille du nombre d'enfant;
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            //met le i enfant dans l'array
            points[i] = transform.GetChild(i);
        }
    }

}
