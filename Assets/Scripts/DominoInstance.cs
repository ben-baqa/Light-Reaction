using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoInstance : MonoBehaviour
{
    public static bool allDown = false;

    public float yThreshold = .5f;
    public bool down = false;

    private Transform head;
    private float yStart;

    private void Start()
    {
        head = transform.GetChild(0);
        yStart = head.position.y;
    }

    void Update()
    {
        allDown = true;
    }

    private void LateUpdate()
    {
        if (down)
            return;
        down =  yStart - head.position.y > yThreshold;
        allDown &= down;
    }
}
