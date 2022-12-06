using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public new Transform camera;
    public Rigidbody playerRb;
    
    public float mouseSensitivity = 100f;
    public float playerSpeed;

    float lookX, lookY, moveX, moveZ;
    float Jump = 10f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {    ////////////////////
        //Player Rotation///
       ////////////////////
        lookX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        lookY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        yRotation -= lookY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        
        transform.Rotate(new Vector3(0f, lookX, 0f));
        camera.transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);

        ////////////////////
        //Player Movement///
        ////////////////////

        //moveX = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        //moveZ = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        //jump = Input.GetAxis("Jump") * playerSpeed * Time.deltaTime;

        //characterController.Move(move*playerSpeed);
    }
    void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal") * Time.deltaTime;
        moveZ = Input.GetAxis("Vertical") * Time.deltaTime;
        Jump = Input.GetAxis("Jump") * Time.deltaTime;

        Vector3 move = transform.right * moveX + transform.forward * moveZ + Vector3.up * Jump;

        //playerRb.AddForce(move*playerSpeed);

        playerRb.velocity = move * playerSpeed;
    }
}
