using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSmovement : MonoBehaviour
{
 
    private Rigidbody rigid;
    [SerializeField] private float moveSpeed = 25f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float fallMult = 2.9f;
    private float distanceToGround = 0.5f;
    private float jumpFac = 1;



    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = 55;
        else moveSpeed = 32;
        rigid.MovePosition(transform.position + (jumpFac * transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime) + (jumpFac * transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime));
        if (Input.GetKeyDown("space") && IsGrounded())
            rigid.velocity = Vector3.up * jumpForce;

        if (rigid.velocity.y < 0)
            rigid.velocity = rigid.velocity + Vector3.up * Physics.gravity.y * fallMult * Time.deltaTime;    //multiplies falling speed

        if (!IsGrounded())
            jumpFac = .4f;
        else jumpFac = 1;

    }



    bool IsGrounded() { return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f); }




}