using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    bool m_isOpen = false;

    Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateDoor();
    }

    void AnimateDoor()
    {
        m_animator.SetBool("IsOpen", m_isOpen);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something is happening!");

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Animation Triggered!");
            m_isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_isOpen = false;
    }
}
