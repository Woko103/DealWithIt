using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointDeal : MonoBehaviour
{
    public GameObject deal;

    void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation (deal.transform.position - transform.position);
    }
}
