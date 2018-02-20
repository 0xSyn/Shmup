using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController: MonoBehaviour {

	public float speed;
	private Rigidbody rb;
    private Vector3 vel;

    void Start () {
		rb = GetComponent<Rigidbody>();
        transform.localScale = new Vector3(1, 3, 1);
        vel = transform.up;
        vel.Normalize();
        rb.velocity = vel*speed;
	}
	
}
