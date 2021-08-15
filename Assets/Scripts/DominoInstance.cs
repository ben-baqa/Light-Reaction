using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoInstance : MonoBehaviour
{
    public static bool allDown = false;

    public float yDownThreshhold = 1f;
    public bool down = false;

    private float yStart;

    private void Start()
    {
        yStart = transform.position.y;
    }

    void Update()
    {
        allDown = true;
    }

    private void LateUpdate()
    {
        if (down)
            return;
        down = transform.position.y - yStart > yDownThreshhold;
        allDown &= down;
    }
}
