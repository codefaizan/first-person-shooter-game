using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public new Transform camera;
    CharacterController characterController;

    Vector3 moveDirection;
    public float playerSpeed;
    public float jumpForce = 6f;
    float gravity = 20f;
    float verticalVelocity;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveDirection *= playerSpeed * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);

        ApplyGravity();

        characterController.Move(moveDirection);
    }

    void ApplyGravity()
    {
        verticalVelocity -= gravity * Time.deltaTime;
        PlayerJump();
        moveDirection.y = verticalVelocity * Time.deltaTime;
    }

    void PlayerJump()
    {
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
            print("isgrounded");
        }
    }

}
