using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Movement")]
    protected float m_currentSpeed;
    protected float m_walkSpeed = 200;
    protected float m_runSpeed = 350;
    protected float m_jumpForce = 10;
    protected Vector3 m_playerMovementInput;
    protected Vector2 m_playerMouseInput;
    [SerializeField]
    protected Transform m_playerCamera;

    [Header("Mouse Settings")]
    [SerializeField]
    protected float m_mouseSensitivity = 1;
    protected float m_xRotation;
    protected float m_yRotation;

    [Header("Components")]
    protected Rigidbody m_rigidbody;
    protected Animator m_animator;
}
