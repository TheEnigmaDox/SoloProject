using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    bool m_isMoving = false;
    bool m_canAttack = false;

    float m_currentAttackTime;
    float m_attackTime = 3f;

    public int m_enemyHealth = 100;

    [SerializeField]
    private Transform m_target;

    private Animator m_animator;

    private NavMeshAgent m_meshAgent;


    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_meshAgent = GetComponent<NavMeshAgent>();
        m_target = GameManager.Instance.m_treasureObjects[Random.Range(0, GameManager.Instance.m_treasureObjects.Count)].transform;
        m_currentAttackTime = m_attackTime;
    }

    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, m_target.position);

        Debug.Log("Distance to Target: " + distanceToTarget);

        if (transform.position != m_target.transform.position)
        {
            m_meshAgent.destination = m_target.transform.position;
        }

        if(m_meshAgent.velocity != Vector3.zero)
        {
            m_isMoving = true;
        }
        else
        {
            m_isMoving = false;
        }

        if(distanceToTarget < 2.5f)
        {
            Debug.Log("Destination reached!");
            Attack();
        }
 
        AnimateEnemy();
    }

    private void AnimateEnemy()
    {
        m_animator.SetBool("IsMoving", m_isMoving);
        m_animator.SetBool("CanAttack", m_canAttack);
    }

    void Attack()
    {
        m_currentAttackTime -= Time.deltaTime;

        if (m_currentAttackTime <= 0)
        {
            m_canAttack = true;
            StartCoroutine(TimeBetweenAttacks());
        }
    }

    IEnumerator TimeBetweenAttacks()
    {
        yield return new WaitForSeconds(1);
        m_canAttack = false;
        m_currentAttackTime = m_attackTime;
    }
}
