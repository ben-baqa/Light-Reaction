using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 1, jumpForce = 10, friction = .2f;
    public float turnRatio = 0.1f;

    public AudioSource jumpSound, jumpSound2, landSound, runSound;

    private Rigidbody rb;
    private ControlKey input;
    private GameObject cam;
    private Animator anim;

    private float ground_dist = 0;
    private bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<ControlKey>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        cam = transform.parent.GetComponentInChildren<CameraController>().gameObject;

        CapsuleCollider col = GetComponent<CapsuleCollider>();
        ground_dist = col.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        LightUp.UpdatePoint(transform.position);
    }

    private void FixedUpdate()
    {
        Vector3 dir = Vector3.zero;

        if (input["forward"])
            dir += cam.transform.forward;
        if (input["backward"])
            dir -= cam.transform.forward;
        if (input["right"])
            dir += cam.transform.right;
        if (input["left"])
            dir -= cam.transform.right;

        bool b = Physics.Raycast(transform.position,
            Vector3.down, ground_dist + 0.02f);
        if (!grounded && b)
            landSound.Play();
        grounded = b;
        anim.SetBool("ground", grounded);

        if (input["jump"] && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            anim.SetTrigger("jump");
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            jumpSound.Play();
            jumpSound2.Play();
        }

        Vector3 v = rb.velocity * (1 - friction);
        rb.velocity = new Vector3(v.x, rb.velocity.y, v.z);

        float s = Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2) +
            Mathf.Pow(rb.velocity.z, 2));
        if (input["backward"] && !input["forward"])
            s *= -1;
        anim.SetFloat("speed", s);

        if (dir != Vector3.zero)
        {
            anim.SetBool("run", true);
            float r = rb.rotation.eulerAngles.y;
            r = Mathf.Lerp(r, cam.transform.rotation.eulerAngles.y, turnRatio);

            rb.rotation = Quaternion.Euler(Vector3.up * r);
            rb.AddForce(dir.normalized * moveForce);
        }
        else
            anim.SetBool("run", false);
    }
}
