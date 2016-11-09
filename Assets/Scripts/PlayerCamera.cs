using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
    private float mouseSensitivity = 2.5f;
    private float minCameraRotation = -90f;
    private float maxCameraRotation = 90f;

    private float rotX;
    private float rotY;

    public Transform mainCamera;

    void Update()
    {
        CameraRotation();
        LockCursorControls();      
    }

    void CameraRotation()
    {
        if (Input.GetAxisRaw("Mouse X") == 0 && Input.GetAxisRaw("Mouse Y") == 0)
        {
            return;
        }

        rotX += Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        rotY += -Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        rotY = Mathf.Clamp(rotY, minCameraRotation, maxCameraRotation);

        transform.rotation = Quaternion.Euler(0f, rotX, 0f);
        mainCamera.rotation = Quaternion.Euler(rotY, rotX, 0f);
    }

    void LockerCursor(bool isLocked)
    {
        if (isLocked == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void LockCursorControls()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LockerCursor(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            LockerCursor(true);
        }
    }
}
