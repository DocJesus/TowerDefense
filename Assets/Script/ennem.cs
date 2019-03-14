using UnityEngine;

public class ennem : MonoBehaviour
{

    public float speed = 10f;
    private Transform target;
    private int wayPointIndex = 0;

	// Use this for initialization
	void Start ()
    {
        target = WayPoints.points[wayPointIndex];   	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (wayPointIndex < WayPoints.points.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (transform.position == target.position && target != WayPoints.points[WayPoints.points.Length - 1])
            {
                wayPointIndex += 1;
                target = WayPoints.points[wayPointIndex];
            }
        }

	}
}
