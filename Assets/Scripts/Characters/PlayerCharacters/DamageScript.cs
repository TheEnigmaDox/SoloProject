using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public GameObject debugSphere;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(960, 540));

            if (Physics.Raycast(ray, out RaycastHit hit, 2))
            {
                debugSphere.transform.position = hit.point;

                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    EnemyCharacter enemy = hit.collider.gameObject.GetComponent<EnemyCharacter>();

                    enemy.m_enemyHealth -= 10;
                }
            }
        }
    }
}
