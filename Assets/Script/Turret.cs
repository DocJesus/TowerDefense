using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("General")]
    private Transform target;
    public float range = 15f;
    private ennem enemyScript;

    [Header("User Bullet (Default)")]
    public float fireRate = 1f;
    private float fireCountDown = 0f; //temps restant avant de tirer au moment de spawn
    public GameObject bulletPrefab;

    [Header("User Laser")]
    public LineRenderer laserBeam;
    public bool userLaser;
    [SerializeField]
    private ParticleSystem laserInpactEffect;
    public Light inpactLight;
    public int damageOverTime = 30;
    public float slowEffect = 50f;

    [Header("Unity SetupField")]
    public Transform firePoint;
    public Transform partToRotate;
    public string ennemyTag = "Ennemy";

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
            enemyScript = target.GetComponent<ennem>();
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
        {
            if (userLaser)
            {
                if (laserBeam.enabled)
                {
                    laserBeam.enabled = false;
                    laserInpactEffect.Stop();
                    inpactLight.enabled = false;
                }
            }
            return;
        }
        //  partToRotate.LookAt(target);
        partToRotate.rotation = Quaternion.LookRotation(target.position - partToRotate.position);

        if (userLaser)
        {
            Laser();    
        }
        else
        {
            if (fireCountDown <= 0f)
            {
                Shoot();
                fireCountDown = 1 / fireRate;
            }

            fireCountDown -= Time.deltaTime;
        }
    }

    void Laser()
    {
        enemyScript.TakeDamage(damageOverTime * Time.deltaTime);

        if (laserBeam.enabled == false)
        {
            laserBeam.enabled = true;
            laserInpactEffect.Play();
            inpactLight.enabled = true;
            slowEffect = slowEffect / 100;
            enemyScript.speed *= slowEffect;
        }

        laserBeam.SetPosition(0, firePoint.position);
        laserBeam.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        laserInpactEffect.transform.rotation = Quaternion.LookRotation(dir);

        laserInpactEffect.transform.position = target.position + dir.normalized * 1.5f;
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
