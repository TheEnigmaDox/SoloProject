using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int m_waveCount = 0;
    int m_killcount = 0;

    private float m_spawnTimer;
    private float m_spawnTime = 3f;

    public Transform TreasureContainer;
    private List<Transform> m_treasureTargets;

    public List<GameObject> EnemyPrefabs;

    [SerializeField]
    List<Transform> m_spawnPoints;

    private void Awake()
    {
        m_treasureTargets = new List<Transform>();
        foreach (Transform child in TreasureContainer)
        {
            if (child.GetComponent<TreasureHealth>() != null)
                m_treasureTargets.Add(child);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTimer = m_spawnTime;

        
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnTimer -= Time.deltaTime;

        if(m_waveCount < WaveConfig.m_levelOneWaveCount && m_spawnTimer <= 0)
        {
            GameObject newEnemy = Instantiate(EnemyPrefabs[0], m_spawnPoints[Random.Range(0, m_spawnPoints.Count)].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyCharacter>().m_spawner = this;
            m_spawnTimer = m_spawnTime;
        }
    }

    public GameObject GetTarget()
    {
        return m_treasureTargets[Random.Range(0, m_treasureTargets.Count)].gameObject;
    }

    public int KillCount
    {
        get { return m_killcount; }
        set { m_killcount = value; }
    }
}
