using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoInstance : MonoBehaviour
{
    public static bool allDown = false;

    public float rotationThreshold = 25;
    public bool down = false;

    private float rotStart;

    private void Start()
    {
        rotStart = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        allDown = true;
    }

    private void LateUpdate()
    {
        if (down)
            return;
        down = Mathf.Abs(transform.rotation.eulerAngles.z - rotStart) > rotationThreshold;
        allDown &= down;
    }
}
