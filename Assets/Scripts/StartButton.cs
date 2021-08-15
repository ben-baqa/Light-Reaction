using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public float pushDistance = 0.5f;

    private Rigidbody rb;
    private Vector3 lastPoint = Vector3.zero;

    private void OnCollisionEnter(Collision collision)
    {
        rb = collision.collider.GetComponent<Rigidbody>();
        if (rb)
        {
            Vector3 v = rb.position;
            if (Vector3.Distance(v, lastPoint) < pushDistance)
                SceneManager.LoadScene(1);
            lastPoint = v;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (rb)
            rb = null;
    }

    private void Update()
    {
        if (rb)
            lastPoint = rb.transform.position;
    }
}
