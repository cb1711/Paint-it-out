using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopper : MonoBehaviour {
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 10f);
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
