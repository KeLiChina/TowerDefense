using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefabs;
    private float countsdown = 4;
    private float timeBetweenWaves = 6;
    private float waveIndex = 1;
    public Transform wayPoint;
	public Text waveCountDownText;
    private IEnumerator m_IESpawnWave;

  

    void Update()
    {
        SpawnWave();
    }

    private void SpawnWave()
    {
        if (countsdown <= 0)
        {
            Debug.Log("Wave Incoming!");
            if (m_IESpawnWave != null)
            {			
                StopCoroutine(m_IESpawnWave);
                m_IESpawnWave = null;
            }
            m_IESpawnWave = IESpawnWave();
            StartCoroutine(IESpawnWave());
            countsdown = timeBetweenWaves;
        }
		waveCountDownText.text = Mathf.Floor(countsdown).ToString();
        countsdown -= Time.deltaTime;
    }
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefabs, wayPoint.position, wayPoint.rotation,transform);
    }

    IEnumerator IESpawnWave()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex++;
    }
}
