using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSlowly : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.rotation *= Quaternion.Euler(0,1f,0);
    }
}
