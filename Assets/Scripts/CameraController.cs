using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Vector2 mouseSensitivity = new Vector2(0.1f, 0.1f);

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

        transform.Rotate(0, mouseDelta.x * mouseSensitivity.x, 0);

        float r = xRot.localEulerAngles.x;
        r += -mouseDelta.y * mouseSensitivity.y;
        if (r < 0)
            r = 0;
        if (r > 90)
            r = 90;

        xRot.localEulerAngles = Vector3.right * r;
    }
}
