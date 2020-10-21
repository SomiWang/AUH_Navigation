using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Align", 2, 1);
    }

    private void Align()
    {
        var rotation = Quaternion.FromToRotation(transform.up, Vector3.up);
        rotation *= transform.rotation;
        transform.rotation = rotation;
    }

}
