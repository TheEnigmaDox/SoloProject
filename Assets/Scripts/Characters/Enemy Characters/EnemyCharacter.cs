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
    public EnemySpawner m_spawner;

    public EnemyType m_enemyType;

    bool m_isMoving = false;
    bool m_canAttack = false;

    float m_currentAttackTime;
    float m_attackTime = 3f;

    public int m_enemyHealth = 100;

    [SerializeField]
    private GameObject m_target;

    private Animator m_animator;

    private NavMeshAgent m_meshAgent;


    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_meshAgent = GetComponent<NavMeshAgent>();
        
        m_currentAttackTime = m_attackTime;
    }

    private void Start()
    {
        m_target = m_spawner.GetTarget();
    }

    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, m_target.transform.position);

        //Debug.Log("Distance to Target: " + distanceToTarget);

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

        if (distanceToTarget < 2.5f)
        {
            m_currentAttackTime -= Time.deltaTime;

            if (m_currentAttackTime <= 0)
            {
                Attack();
                m_currentAttackTime = m_attackTime;
            }
        }
 
        AnimateEnemy();
        DestroyMe();
    }

    private void AnimateEnemy()
    {
        m_animator.SetBool("IsMoving", m_isMoving);
        m_animator.SetBool("CanAttack", m_canAttack);
    }

    void Attack()
    {
        transform.LookAt(m_target.transform.position, Vector3.up);

        TreasureHealth targetHealth = m_target.GetComponent<TreasureHealth>();

        m_canAttack = true;

        targetHealth.TakeDamage(10);
        StartCoroutine(TimeBetweenAttacks());
    }

    void DestroyMe()
    {
        if(m_enemyHealth <= 0)
        {
            m_spawner.KillCount++;
            Destroy(this.gameObject);
        }
    }

    IEnumerator TimeBetweenAttacks()
    {
        yield return new WaitForSeconds(1f);
        m_canAttack = false;
    }
}
