using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkeletonWarrior : Character
{ 
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_playerMovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        m_playerMouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        MovePlayer();
        MoveCamera();
    }

    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(m_playerMovementInput) * m_movementSpeed * Time.deltaTime;
        m_rigidbody.velocity = new Vector3(moveVector.x, m_rigidbody.velocity.y, moveVector.z);

        if(m_rigidbody.velocity.z != 0 && Input.GetKey(KeyCode.W))
        {
            m_animator.SetBool("MovingForward", true);
        }
        else
        {
            m_animator.SetBool("MovingForward", false);
        }

        if(m_rigidbody.velocity.z != 0 && Input.GetKey(KeyCode.S))
        {
            m_animator.SetBool("MovingBackward", true);
        }
        else
        {
            m_animator.SetBool("MovingBackward", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            m_rigidbody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }
    }

    private void MoveCamera()
    {
        m_xRotation -= m_playerMouseInput.y * m_mouseSensitivity;

        m_xRotation = Mathf.Clamp(m_xRotation, -60, 60);

        transform.Rotate(0f, m_playerMouseInput.x * m_mouseSensitivity, 0f);
        m_playerCamera.transform.localRotation = Quaternion.Euler(m_xRotation, 0, 0);
    }
}
