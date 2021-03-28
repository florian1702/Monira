using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contoller : MonoBehaviour
{
    [SerializeField] CharacterController Controller;
    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] public float jumpHeight = 3f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    bool isGrounded;

    public Vector3 velocity;
    public float gravity = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * xValue + transform.forward *zValue;

        Controller.Move(move * moveSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        Controller.Move(velocity*Time.deltaTime);
    }
}
