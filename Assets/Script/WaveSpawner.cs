﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    [SerializeField]
    private Transform StartPoint;
    [SerializeField]
    private Transform ennemyPrefab;
    [SerializeField]
    private float timeBetweenWaves = 5.5f;

    [SerializeField]
    private float countDown = 5f;

    private int wave = 0;

    [SerializeField]
    private Text waveCountDownTimer;

	// Update is called once per frame
	void Update ()
    {
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
        wave++;
        Debug.Log("Appartion d'une nouvelle vague");
        for (int i = 0; i < wave; i++)
        {
            SpawnEnnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnnemy()
    {
        Instantiate(ennemyPrefab, StartPoint.position, StartPoint.rotation);
    }
 
}
