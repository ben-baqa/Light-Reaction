using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    private GameObject shadow;
    private float maxDistance = 500;

    // Start is called before the first frame update
    void Start()
    {
        shadow = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.down, maxDistance);
        if(hits.Length > 0)
        {
            shadow.SetActive(true);
            Vector3 p = hits[0].point;
            foreach (RaycastHit h in hits)
                if (h.point.y > p.y)
                    p = h.point;
            shadow.transform.position = p;
        }
        else
        {
            shadow.SetActive(false);
        }
    }
}
