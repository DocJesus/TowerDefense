using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float explosionRadius = 0f;

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
        transform.LookAt(target);
	}

    private void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Damage(Transform ennemy)
    {
        Destroy(ennemy.gameObject);
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Explode()
    {
        //créer une sphere qq part d'une certaine taille et return tout les objets en colision avec
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Ennemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
