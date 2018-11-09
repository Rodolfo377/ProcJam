using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTransform : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeScale(Vector3 newScale)
    {
        transform.localScale = newScale;
        Debug.Log("Object name: " + this.name + " new scale: "+newScale);
    }
}
