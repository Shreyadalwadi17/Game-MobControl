using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPlatform : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
  
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("leftblock"))
        {
            rb.velocity = Vector3.right * speed;
        }
        if (collision.gameObject.CompareTag("rightblock"))
        {
            rb.velocity = Vector3.left * speed;
        }
    }
}
