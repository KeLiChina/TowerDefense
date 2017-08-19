using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner instance;
    public Transform enemyPrefabs;
    private float countsdown = 4;
    private float timeBetweenWaves = 6;
    private float waveIndex = 1;
    public Transform wayPoint;
    public Text waveCountDownText;
    private IEnumerator m_IESpawnWave;
    public List<Enemy> Enemys;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        SpawnWave();
     
    }

    private void SpawnWave()
    {
        if (countsdown <= 0)
        {

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
       Transform enemy = Instantiate(enemyPrefabs, wayPoint.position, wayPoint.rotation, transform);
        Enemys.Add(enemy.GetComponent<Enemy>());
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
