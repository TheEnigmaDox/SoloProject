using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType 
{ 
    Barbarian,
    Knight, 
    Mage,
    Rogue
}

public class EnemyCharacter : MonoBehaviour
{
    public EnemyType m_enemyType;

    public int m_enemyHealth = 100;
}
