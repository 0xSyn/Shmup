using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject shot;
    public Transform shotSpawn;
    public GameObject pc;
    public float fireRate = 10.5f;
    public float nextFire = 0.0f;
    // Use this for initialization
    void Start () {
        pc = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation.SetLookRotation(pc.transform.position.x, pc.transform.position.x, pc.transform.position.x);
        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

            //Instantiate(shot, shotSpawn.position, new Quaternion(1,yaw,0,1));

            //AudioSource audio = GetComponent<AudioSource>();
            //audio.Play();

        }
    }
}
