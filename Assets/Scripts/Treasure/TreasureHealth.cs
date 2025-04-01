using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureHealth : MonoBehaviour
{
    [SerializeField] private int m_treasureHealth = 100;

    //private void Start()
    //{
    //    m_treasureHealth = 100;
    //}

    // Update is called once per frame
    void Update()
    {
        //Debug.Assert(m_treasureHealth == 100, $"{this.name} now has health ({m_treasureHealth})");
        if (m_treasureHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        //Debug.Log($"Attacking {this.name} that has health {m_treasureHealth}.");
        m_treasureHealth -= damage;
        //Debug.Log($"{this.name} now has health {m_treasureHealth}.");
    }
}
