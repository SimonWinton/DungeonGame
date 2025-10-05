using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float turnSpeed = 20f;
    public float m_Speed = 2f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Start() {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //print("hor " + horizontal);
        //print("ver " + vertical);
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();
        //print("m_Movement " + m_Movement);

        //Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //m_Rigidbody.MovePosition(transform.position + m_Input * m_Animator.deltaPosition.magnitude * m_Speed);

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("isWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    void OnAnimatorMove() {
        m_Rigidbody.MovePosition(transform.position + m_Movement * Time.fixedDeltaTime * m_Speed);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
