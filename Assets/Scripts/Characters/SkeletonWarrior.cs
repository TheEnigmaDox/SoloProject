using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkeletonWarrior : PlayerCharacter
{
    // Start is called before the first frame update
    private void Start()
    {
        m_mainCam = Camera.main;
        m_animator = GetComponent<Animator>();  

        m_currentSpeed = m_walkSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        AnimateCharacter();
        MoveCamera();
        MovePlayer();
    }

    private void LateUpdate()
    {
        m_mainCam.transform.SetPositionAndRotation(m_viewPoint.position, m_viewPoint.rotation);
    }

    //Function to take input and move camera based on mouse input.
    private void MoveCamera()
    {
        if (SettingsManager.m_invertMouse)
        {
            m_verticalRotStore = Mathf.Clamp(m_verticalRotStore, -60f, 25);
            m_viewPoint.rotation = Quaternion.Euler(-m_verticalRotStore, m_viewPoint.rotation.eulerAngles.y, m_viewPoint.rotation.eulerAngles.z);
        }
        else
        {
            m_verticalRotStore = Mathf.Clamp(m_verticalRotStore, -25f, 60);
            m_viewPoint.rotation = Quaternion.Euler(m_verticalRotStore, m_viewPoint.rotation.eulerAngles.y, m_viewPoint.rotation.eulerAngles.z);
        }

        m_mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y") * m_mouseSensitivity);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + m_mouseInput.x, transform.rotation.eulerAngles.z);

        m_verticalRotStore += m_mouseInput.y;
    }

    //Function to take input and move player based on keyboard input.
    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxisRaw("Vertical") > 0)
        {
            m_currentSpeed = m_runSpeed;
        }
        else
        {
            m_currentSpeed = m_walkSpeed;
        }

        m_moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        float yVel = m_movement.y;
        m_movement = ((transform.forward * m_moveDirection.z) + (transform.right * m_moveDirection.x)).normalized * m_currentSpeed;
        m_movement.y = yVel;

        if (m_characterController.isGrounded)
            m_movement.y = 0;

        if (Input.GetButtonDown("Jump") && m_characterController.isGrounded)
            m_movement.y = m_jumpForce;

        m_movement.y += Physics.gravity.y * Time.deltaTime;

        m_characterController.Move(m_movement * Time.deltaTime);
    }

    //Function to animate character.
    private void AnimateCharacter()
    {
        if(Input.GetAxisRaw("Vertical") > 0)
            m_animator.SetFloat("Movement", 1);
        else if(Input.GetAxisRaw("Vertical") == 0)
            m_animator.SetFloat("Movement", 0);
        else if (Input.GetAxisRaw("Vertical") < 0)
            m_animator.SetFloat("Movement", -1);
    }
}
