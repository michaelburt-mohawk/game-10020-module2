using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    CharacterController controller;
    Vector3 velocity;
    Animator animator;
    Collider shovelCollider;

    public InputActionReference moveInput;
    public float moveSpeed = 5.0f;
    public float gravity = -9.81f;
    public GameObject shovel;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        shovelCollider = shovel.GetComponent<Collider>();

        shovelCollider.enabled = false;
    }

    void Update()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector2 moveDirection = moveInput.action.ReadValue<Vector2>();

        Vector3 move = Vector3.right * moveDirection.x + Vector3.forward * moveDirection.y;
        Vector3 moveVelocity = move * moveSpeed;

        velocity.y += gravity * Time.deltaTime;

        moveVelocity.y = velocity.y;
        controller.Move(moveVelocity * Time.deltaTime);


        Vector3 horizontalVelocity = new Vector3(moveVelocity.x, 0f, moveVelocity.z);
        if (horizontalVelocity.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(horizontalVelocity);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                15f * Time.deltaTime
            );
        }

        Mouse mouse = Mouse.current;
        if (mouse != null && mouse.leftButton.wasPressedThisFrame)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
            {
                animator.SetTrigger("StartAttack");
            }
        }
    }

    public void EnableHitbox(int value)
    {
        shovelCollider.enabled = value == 1 ? true : false;
    }
}
