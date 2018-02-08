using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    public bool lockCursor;
    public float mouseSensitivity = 10;
    public Transform target;
    public float dstFromTarget = 2;
    public Vector2 pitchMinMax = new Vector2(-40, 85);

    public float rotationSmoothTime = .12f;
    public Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    bool isLock = false;
    public GameObject menu;

    float yaw;
    float pitch;
    

    // Use this for initialization
    void Start () {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
	}

    private void LateUpdate()
    {
        if (!menu.activeSelf)
        {
            if (!Input.GetKey(KeyCode.LeftAlt))
            {
                yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
                pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
                pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

                currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
                transform.eulerAngles = currentRotation;

                transform.position = target.position - transform.forward * dstFromTarget;
            }
                
        }
    }

    // Update is called once per frame
    void Update () {
        if (menu.activeSelf || Input.GetKey(KeyCode.LeftAlt))
        {
            Screen.lockCursor = false;
        }
        else
        {
            Screen.lockCursor = true;
        }
	}
    
}
