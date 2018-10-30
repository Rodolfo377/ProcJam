using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    public float windSpeed;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //transform.position.x = windSpeed;
        transform.position = new Vector2(transform.position.x + windSpeed, transform.position.y);
	}
}
