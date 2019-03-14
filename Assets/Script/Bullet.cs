using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject ImpactEffect;
    private Transform target;

    public float speed = 70f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        //soustrer la position de la target et la notre pour donner la dist
        Vector3 dir = target.position - transform.position;
        //la distance qu'on doit faire par frame
        float distanceFrame = speed * Time.deltaTime;

        //si la distance entre la balle et la cible est plus petite que la distance à parcourir alors on est coler à la cible
        if (dir.magnitude <= distanceFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceFrame, Space.World);
	}

    private void HitTarget()
    {
        Destroy(gameObject);
        GameObject effectIns = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2.3f);
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }
}
