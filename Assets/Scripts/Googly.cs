using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Googly : MonoBehaviour
{
    public float elastic_force = .1f, parent_speed_ratio = .1f,
        eye_turn_speed = .2f, friction = .1f;

    public Transform toFollow;
    
    private Vector3 prev_pos;

    private Transform cam;
    private Vector3 offset;

    private Vector3 vel = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        prev_pos = toFollow.position;
        cam = transform.parent.GetComponentInChildren<CameraController>().transform;
        offset = transform.localPosition;
    }

    private void FixedUpdate()
    {
        float r = transform.rotation.eulerAngles.y;
        r = Mathf.Lerp(r, cam.transform.rotation.eulerAngles.y, eye_turn_speed);

        transform.rotation = Quaternion.Euler(Vector3.up * r);

        Vector3 p = toFollow.position;

        vel -= (p - prev_pos) * parent_speed_ratio;
        vel += (offset - (transform.position - toFollow.position)) * elastic_force;
        vel *= (1- friction);

        transform.position += vel;
        prev_pos = p;
    }
}
