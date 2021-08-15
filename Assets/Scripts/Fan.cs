using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float power;
    
    private List<Rigidbody> bodies = new List<Rigidbody>();



    [System.Serializable]
    public class blowBox{
        public Vector3 size, offset;
        public float distanceRatio = 1;
    }
}
