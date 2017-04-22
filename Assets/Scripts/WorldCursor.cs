using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCursor : MonoBehaviour {

    private MeshRenderer meshRenderer;

    private Vector3 oriRaycast;
    private Vector3 dirRaycast;

    private RaycastHit hitInfo;
    
    // Use this for initialization
    void Start () {
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        oriRaycast = Camera.main.transform.position;
        dirRaycast = Camera.main.transform.forward;
        
        if (Physics.Raycast(oriRaycast, dirRaycast, out hitInfo)) {
            meshRenderer.enabled = true;
            for(int i = 0; i < meshRenderer.gameObject.transform.childCount; i++)
                meshRenderer.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = true;

            //meshRenderer.material.color = Color.red;
            this.transform.position = hitInfo.point;
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, dirRaycast);
        } else {
            //meshRenderer.material.color = Color.gray;
            meshRenderer.enabled = false;
            for (int i = 0; i < meshRenderer.gameObject.transform.childCount; i++)
                meshRenderer.gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
        }

	}
}
