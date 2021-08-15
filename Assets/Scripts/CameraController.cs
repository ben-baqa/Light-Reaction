using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Vector2 mouseSensitivity = new Vector2(0.1f, 0.1f);
    public Vector2 controllerSensitivity = new Vector2(.5f, .5f);

    private Transform xRot, playerBody;

    // Start is called before the first frame update
    void Start()
    {
        xRot = transform.GetChild(0);
        playerBody = transform.parent.GetComponentInChildren<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        transform.position = playerBody.position;
        Vector2 mouseDelta = Pointer.current.delta.ReadValue();
        mouseDelta.x *= mouseSensitivity.x;
        mouseDelta.y *= mouseSensitivity.y;

        Vector2 padDelta = Vector2.zero;
        if (Gamepad.current != null)
            padDelta = Gamepad.current.rightStick.ReadValue();
        padDelta.x *= controllerSensitivity.x;
        padDelta.y *= controllerSensitivity.y;

        mouseDelta += padDelta;

        transform.Rotate(0, mouseDelta.x, 0);

        float r = xRot.localEulerAngles.x;
        r += -mouseDelta.y;
        if (r < 0)
            r = 0;
        if (r > 90)
            r = 90;

        xRot.localEulerAngles = Vector3.right * r;
    }
}
