using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public new Transform camera;
    public float mouseSensitivity = 100f;
    float lookX, lookY;
    float yRotation = 0f;

    private void Update()
    {
        MouseLook();
    }
    void MouseLook()
    {
        lookX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        lookY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        yRotation -= lookY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.Rotate(new Vector3(0f, lookX, 0f));
        camera.transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
    } //player look around
}
