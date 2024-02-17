using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMove : MonoBehaviour
{
    public float shootForce;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = rb.transform.forward * shootForce;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            Destroy(other.gameObject);
        }
    }
}
