using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {
    public float speed;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 1) * speed;

    }
}
