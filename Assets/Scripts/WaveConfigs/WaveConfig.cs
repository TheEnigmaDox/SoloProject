using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Gonfig", fileName = "New Wave Congig")]
public class WaveConfig : ScriptableObject
{
    public int m_waveCount;

    [SerializeField]
    List<GameObject> m_targets;
    public List<GameObject> GetTargets()
    {
        return m_targets;
    }

    public int GetWaveCount()
    {
        return m_waveCount;
    }
}
