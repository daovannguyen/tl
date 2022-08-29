using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DapLai : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponentInParent<Rigidbody>();
        rb.AddForce(new Vector3(rb.velocity.x * -1, rb.velocity.y, rb.velocity.z * -1));
    }
}
