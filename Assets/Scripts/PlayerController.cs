using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
    public int mode;
	public float fireRate = 0.5f;
	public float nextFire = 0.0f;
    private float yaw,yaw2;
    // Use this for initialization
    void Start () {
        rb = GetComponentInChildren<Rigidbody>();
        mode = 1;

	}
	
	void Update() {
		if(Input.GetAxis("RightTrigger")!=0 && Time.time > nextFire) {
			nextFire = Time.time + fireRate;

			//Instantiate(shot, shotSpawn.position, new Quaternion(1,yaw,0,1));
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            AudioSource audio = GetComponent<AudioSource>();
			audio.Play();

		}
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
        yaw = Input.GetAxis("RightAnalogX");
        yaw2 = Input.GetAxis("RightAnalogY");
        Vector3 movement;


        switch (mode) {
            case 0://vert shmup
                movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                rb.velocity = movement * speed;
                rb.rotation = Quaternion.Euler(0.0f, 0, rb.velocity.x * -tilt);
                break;

            case 1://horiz shmup
                movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                rb.velocity = movement * speed;
                rb.rotation = Quaternion.Euler(0,90, 45);


                break;
            case 2://twinstick
                movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                rb.velocity = movement * speed;
                rb.rotation = Quaternion.LookRotation(new Vector3(yaw,0,-yaw2), Vector3.up);
                break;

            default: break;

        }
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );


    }
}
