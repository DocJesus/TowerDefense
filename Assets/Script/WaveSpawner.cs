using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Wave[] waves;
    [SerializeField]
    private Transform StartPoint;
    [SerializeField]
    private float timeBetweenWaves = 5.5f;

    [SerializeField]
    private float countDown = 5f;

    private int waveCount = 0;

    [SerializeField]
    private Text waveCountDownTimer;

    public GameManager gameManager;

    public static int ennemyAlive = 0;

	// Update is called once per frame
	void Update ()
    {

        if (waveCount == waves.Length && ennemyAlive == 0)
        {
            gameManager.WinLevel();
            this.enabled = false;
            return;
        }

        if (countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        waveCountDownTimer.text = string.Format("{0:00.00}", countDown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStat.rounds++;



        Wave wave = waves[waveCount];

        Debug.Log("Appartion d'une nouvelle vague");
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        ennemyAlive += wave.count;
        waveCount++;
    }

    void SpawnEnnemy(GameObject ennemy)
    {
        Instantiate(ennemy, StartPoint.position, StartPoint.rotation);
    }
 
}
