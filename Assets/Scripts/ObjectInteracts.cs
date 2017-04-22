using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteracts : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnSelect() {
        if (!this.GetComponent<Rigidbody>()) {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }

}
