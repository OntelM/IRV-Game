using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {


    public Transform playerCamera;


    float gravity = -12f;
    float velocityY;

    public float walkSpeed = 2f;
    public float runSpeed = 6f;
    public float jumpHeight = 1f;

    public float turnSmootTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmootTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    CharacterController controller;

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        playerCamera = Camera.main.transform;
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmootTime);
        }
        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmootTime);

        velocityY += Time.deltaTime * gravity;

        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;
        controller.Move(velocity * Time.deltaTime);
        currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;

        if (controller.isGrounded)
        {
            velocityY = 0;
        }

        float animationSpeedPercent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * .5f);
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmootTime, Time.deltaTime);
    }

    void Jump()
    {
        if (controller.isGrounded)
        {
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
        }
    }
    
}
