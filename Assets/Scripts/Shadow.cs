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
            shadow.transform.position = hits[1].point;
        }
        else
        {
            shadow.SetActive(false);
        }
    }
}
