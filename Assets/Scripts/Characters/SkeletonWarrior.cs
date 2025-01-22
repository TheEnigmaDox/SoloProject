using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonWarrior : Character
{
    [SerializeField]
    private Transform m_viewPoint;

    // Start is called before the first frame update
    void Start()
    {
        m_characterController = GetComponent<CharacterController>();
        m_currentSpeed = m_walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter(m_viewPoint);

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            CharacterRun();
        }
        else
        {
            CharacterWalk();
        }
    }
}
