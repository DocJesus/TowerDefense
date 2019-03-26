using UnityEngine;

public class ennem : MonoBehaviour
{

    public float speed = 10f;
    private Transform target;
    private int wayPointIndex = 0;

    public float health = 100;
    public int valueMoney = 50;

    public GameObject deathParticule;

	// Use this for initialization
	void Start ()
    {
        target = WayPoints.points[wayPointIndex];   	
	}

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStat.money += valueMoney;
        GameObject deathEffect = (GameObject)Instantiate(deathParticule, transform.position, Quaternion.identity);
        Destroy(deathEffect, 3f);
        Destroy(gameObject);
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
