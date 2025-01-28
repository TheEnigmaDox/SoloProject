using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Movement")]
    protected float m_moveSpeed = 5f;

    [Header("Mouse Settings")]
    protected float m_mouseSensitivity = 1f;
    private float m_xRotation = 0f;

    protected Rigidbody m_rigidBody;

    protected void MoveCamera()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * m_mouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * m_mouseSensitivity;

        m_xRotation -= mouseY;
        m_xRotation = Mathf.Clamp(m_xRotation, -60f, 60f);
        Camera.main.transform.localRotation = Quaternion.Euler(m_xRotation, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
    }

    protected void MoveCharacter()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = (Camera.main.transform.forward * verticalInput + Camera.main.transform.right * horizontalInput).normalized;

        Vector3 movement = direction * m_moveSpeed;
        Vector3 velocity = new Vector3(movement.x, m_rigidBody.velocity.y, movement.z);
        m_rigidBody.velocity = velocity;
    }
}
