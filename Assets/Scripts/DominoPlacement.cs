using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DominoPlacement : MonoBehaviour
{
    public GameObject[] meshPrefabs;
    public GameObject dominoPrefab;

    private LineRenderer line;
    private List<Domino> dominos = new List<Domino>();

    private Vector3 gizmoSize = new Vector3(1, 4.5f, 2.625f);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        foreach(Domino d in dominos)
        {
            Gizmos.matrix = transform.localToWorldMatrix *
                Matrix4x4.Translate(d.point + Vector3.up * 2.25f) *
                Matrix4x4.Rotate(Quaternion.Euler(Vector3.up * (d.rotation + 90)));
            Gizmos.DrawWireCube(Vector3.zero, gizmoSize);
        }
    }

    void Start()
    {
        line = GetComponent<LineRenderer>();
        RegenerateSet();
        if (Application.isPlaying)
        {
            PlaceAll();
            line.enabled = false;
        }
    }

    private void Update()
    {
        RegenerateSet();
    }

    private void RegenerateSet()
    {
        dominos = new List<Domino>();

        Vector3 p = line.GetPosition(0);
        for(int i = 1; i < line.positionCount; i++)
        {
            Vector3 v = line.GetPosition(i);
            Vector3 diff = v - p;
            float r = Mathf.Rad2Deg * Mathf.Atan2(diff.x, diff.z);
            dominos.Add(new Domino(RandomDomino(), p, r));
            p = v;
        }

        Vector3 v2 = line.GetPosition(line.positionCount - 2);
        v2 = p - v2;
        float a = Mathf.Rad2Deg * Mathf.Atan2(v2.x, v2.z);
        dominos.Add(new Domino(RandomDomino(), p, a));
    }

    private GameObject RandomDomino()
    {
        return meshPrefabs[Random.Range(0, meshPrefabs.Length)];
    }

    private void PlaceAll()
    {
        foreach (Domino d in dominos)
            d.Place(transform, dominoPrefab);
    }

    private class Domino
    {
        private GameObject prefab;
        public Vector3 point;
        public float rotation;

        public Domino(GameObject g, Vector3 p, float r)
        {
            prefab = g;
            point = p;
            rotation = r;
        }

        public void Place(Transform t, GameObject parent)
        {
            GameObject solid = Instantiate(parent, t);
            solid.transform.localPosition = point;
            solid.transform.localRotation =
                Quaternion.Euler(Vector3.up * (rotation + 90));

            Instantiate(prefab, solid.transform);
        }
    }
}
