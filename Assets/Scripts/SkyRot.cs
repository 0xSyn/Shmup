using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRot : MonoBehaviour {
    public Vector3 rot;
    public float rotSpd;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rot*rotSpd * Time.deltaTime);
	}
}
