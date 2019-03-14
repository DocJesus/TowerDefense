using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;

    private Transform target;
    public float range = 15f;

    public Transform partToRotate;

    public string ennemyTag = "Ennemy";

    public float fireRate = 1f;
    private float fireCountDown = 0f; //temps restant avant de tirer au moment de spawn

	// Use this for initialization
	void Start ()
    {
        //appel cett fonction toute les X secondes, au leu de l'appeler toute les frames
        InvokeRepeating("UpdateTarget", 0f, 0.5f);	
	}
	
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(ennemyTag);
        float minDist = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (minDist > distanceToEnemy)
            {
                minDist = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && minDist <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

	// Update is called once per frame
	void Update ()
    {
        if (target == null)
            return;
        //  partToRotate.LookAt(target);
        partToRotate.rotation = Quaternion.LookRotation(target.position - partToRotate.position) * Quaternion.Euler(0, 90, 0);

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1 / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    //fait une sphere autour de la tourelle pour montrer sa porté
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Shoot()
    {
        GameObject insOBJ = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = insOBJ.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}
