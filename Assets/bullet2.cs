using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private Vector3 vel;

    void Start() {
        rb = GetComponent<Rigidbody>();
        
        vel = transform.up;
        vel.Normalize();
        rb.velocity = vel * speed;
    }
}
