using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int m_levelOneWaveCount = 0;

    [SerializeField]
    List<WaveConfig> waveConfig;

    public List<GameObject> m_targetTreasure;

    private void Awake()
    {
        m_levelOneWaveCount = waveConfig[0].GetWaveCount();
        m_targetTreasure = waveConfig[0].GetTargets();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
