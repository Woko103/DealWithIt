using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementVertical : MonoBehaviour
{
    public int range;
    public Rigidbody rb;
    public float forwardForce;
    private Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.z >= initialPos.z + range)
        {
            forwardForce = forwardForce * -1;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
            rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z - 0.5f);
        }
        if(rb.position.z <= initialPos.z - range)
        {
            forwardForce = forwardForce * -1;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z + 0.5f);
        }
        rb.position = rb.position + this.transform.forward * forwardForce * Time.deltaTime;
    }
}
