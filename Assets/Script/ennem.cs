using UnityEngine;
using UnityEngine.UI;

public class ennem : MonoBehaviour
{
    private bool isALive = true;
    public float speed = 10f;
    private Transform target;
    private int wayPointIndex = 0;

    public float health = 100;
    private float tmpHealth;
    public int valueMoney = 50;

    public GameObject deathParticule;

    public Image healthBar;

	// Use this for initialization
	void Start ()
    {
        target = WayPoints.points[wayPointIndex];
        tmpHealth = health;
	}

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / tmpHealth;

        if (health <= 0 && isALive == true)
        {
            Die();
        }
    }

    private void Die()
    {
        isALive = false;
        PlayerStat.money += valueMoney;
        GameObject deathEffect = (GameObject)Instantiate(deathParticule, transform.position, Quaternion.identity);
        Destroy(deathEffect, 3f);
        Destroy(gameObject);
        WaveSpawner.ennemyAlive--;
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

        //si l'ennemy arrive à la fin il se détruit et met des points de dégats au joueur
        if (wayPointIndex == WayPoints.points.Length - 1 && (Vector3.Distance(transform.position, target.position) <= 0.1f))
        {
            HitPlayer();
            Destroy(gameObject);
            return;
        }

	}

    void HitPlayer()
    {
        PlayerStat.lives -= 1;
    }
}
