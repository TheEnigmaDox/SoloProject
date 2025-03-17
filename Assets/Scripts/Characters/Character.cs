using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [Header("Movement Speed")]
    protected float m_currentSpeed;
    [SerializeField]
    protected float m_walkSpeed = 5f;
    [SerializeField]
    protected float m_runSpeed = 10f;

    [Header("Character Jumping")]
    protected float m_jumpForce = 6f;

    [Header("Camera Movement")]
    protected float m_mouseSensitivity = 1f;
    protected float m_verticalRotStore;
    protected Vector2 m_mouseInput;
    [SerializeField]
    protected Transform m_viewPoint;

    [Header("Player Movement")]
    protected float m_gravity = -9.81f;
    protected Vector3 m_moveDirection;
    protected Vector3 m_movement;
    [SerializeField]
    protected CharacterController m_characterController;

    [Header("Components/GameObjects")]
    protected Animator m_animator;
    protected Camera m_mainCam;
}

public class EnemeyCharacter : MonoBehaviour
{

}
