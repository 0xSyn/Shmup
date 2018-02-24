using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject shot;
    public Transform shotSpawn;
    private Rigidbody pc;
    private Rigidbody rb;
    public float speed = 1;
    public float fireRate = 10.5f;
    public float nextFire = 0.0f;

    void Start () {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, -1) * speed;
    }
	

	void Update () {
        GetComponent<Rigidbody>().transform.LookAt(new Vector3(pc.transform.position.x, pc.transform.position.y, pc.transform.position.z));
        
        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

        }
    }
}
