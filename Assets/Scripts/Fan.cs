using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Fan : MonoBehaviour
{
    public float power = 100;
    public BlowBox blowbox;
    
    private List<Rigidbody> bodies = new List<Rigidbody>();
    private BoxCollider col;

    private void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = new Color(0.1f, 0.4f, 0.6f);
        Gizmos.DrawWireCube(blowbox.offset + blowbox.size / 2, 
            blowbox.size);

        Vector3 arrowTip = blowbox.offset + blowbox.size / 2 +
            Vector3.up * blowbox.size.y * .4f;
        Gizmos.DrawLine(arrowTip + Vector3.down * blowbox.size.y * .8f,
            arrowTip);

        float headWidth = blowbox.size.y * .1f;
        Vector3 arrowBack = arrowTip + Vector3.down * headWidth * 2;
        headWidth *= power / 10;
        Gizmos.DrawLine(arrowTip, arrowBack + Vector3.left * headWidth);
        Gizmos.DrawLine(arrowTip, arrowBack + Vector3.right * headWidth);
        Gizmos.DrawLine(arrowTip, arrowBack + Vector3.forward * headWidth);
        Gizmos.DrawLine(arrowTip, arrowBack + Vector3.back * headWidth);
    }

    private void Start()
    {
        if (Application.isPlaying)
        {
            if (!GetComponent<BoxCollider>())
                col = gameObject.AddComponent<BoxCollider>();

            col.size = blowbox.size;
            col.center = blowbox.offset + blowbox.size / 2;
            col.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bodies.Add(other.GetComponent<Rigidbody>());
    }

    private void OnTriggerExit(Collider other)
    {
        bodies.Remove(other.GetComponent<Rigidbody>());
    }

    private void FixedUpdate()
    {
        foreach(Rigidbody rb in bodies)
        {
            rb.AddForce(transform.up * power *
                (blowbox.size.y -
                (rb.position.y - (transform.position.y + blowbox.offset.y))));
        }
    }


    [System.Serializable]
    public class BlowBox{
        public Vector3 size, offset;
    }
}