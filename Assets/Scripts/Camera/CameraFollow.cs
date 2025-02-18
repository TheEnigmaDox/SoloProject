using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float m_minDistance = 1f;
    [SerializeField]
    private float m_maxDistance = 4f;
    [SerializeField]
    private float m_smoothSpeed = 10f;

    [SerializeField]
    Transform m_playerTransform;
    [SerializeField]
    LayerMask m_obstacleMask;

    private Vector3 m_desiredPosition;
    private Vector3 m_currentVelocity = Vector3.zero;

    private void Start()
    {
        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        if(!m_playerTransform) return;

        m_desiredPosition = (m_playerTransform.position + new Vector3(0, 3.5f, -4)) - transform.forward * m_maxDistance;

        RaycastHit hit;
        if (Physics.Raycast(m_playerTransform.position, (m_desiredPosition - m_playerTransform.position).normalized, out hit, m_maxDistance, m_obstacleMask))
        {
            float newDistance = Mathf.Clamp(hit.distance - 0.2f, m_minDistance, m_maxDistance);

            m_desiredPosition = m_playerTransform.position - transform.forward * newDistance;
        }

        transform.position = Vector3.SmoothDamp(transform.position, m_desiredPosition, ref m_currentVelocity, m_smoothSpeed * Time.deltaTime);
    }
}
