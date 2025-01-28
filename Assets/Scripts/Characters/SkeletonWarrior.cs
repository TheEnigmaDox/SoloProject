using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkeletonWarrior : Character
{
    [SerializeField]
    private Transform m_viewPoint;

    // Start is called before the first frame update
    void Start()
    {
        //m_characterController = GetComponent<CharacterController>();
        m_rigidBody = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }
}
