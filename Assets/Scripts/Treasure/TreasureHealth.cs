using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureHealth : MonoBehaviour
{
    public int m_treasureHealth = 100;

    // Update is called once per frame
    void Update()
    {
        if(m_treasureHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        m_treasureHealth -= damage;
    }
}
