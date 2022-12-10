using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public new Transform camera;
    //public Rigidbody playerRb;
    CharacterController characterController;


    public float mouseSensitivity = 100f;
    Vector3 moveDirection;
    public float playerSpeed;
    public float jumpForce = 6f;
    float gravity = 20f;
    float verticalVelocity;

    float lookX, lookY, moveX, moveZ;
    float yRotation = 0f;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        PlayerMove();

        PlayerLook();

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

    void PlayerLook()
    {
        lookX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        lookY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        yRotation -= lookY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.Rotate(new Vector3(0f, lookX, 0f));
        camera.transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
    } //player look around

}
