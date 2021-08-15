using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoChad : MonoBehaviour
{
    private Vector3 scale, origin, diff;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
        origin = transform.GetChild(0).position;
        transform.GetChild(0).SetParent(transform.parent);
        diff = transform.position - origin;
    }

    // Update is called once per frame
    void Update()
    {
        if (!DominoInstance.allDown)
        {
            float s = (1 + GameManager.dominosDown / 100);
            transform.localScale = scale * s;
            transform.position = origin + diff * s;
        }
        else
            if (transform.localScale.magnitude < 10000)
            transform.localScale = transform.localScale * 1.05f;
    }
}
