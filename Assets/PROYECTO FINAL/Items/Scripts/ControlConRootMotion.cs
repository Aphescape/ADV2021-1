using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlConRootMotion : MonoBehaviour
{
    public float speed = 2F;
    public float speedGiros = 2F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    Animator animator;
    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        animator.SetFloat("horizontal", H * speedGiros);
        animator.SetFloat("vertical", V * speed);
    }
}
