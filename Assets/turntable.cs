using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turntable:MonoBehaviour {
	public float turnSpeed = 10f;

	void Update() {
		transform.Rotate(new Vector3(0, Time.deltaTime*turnSpeed, 0));
		//Debug.Log(transform.rotation.eulerAngles.y);
		if (transform.rotation.eulerAngles.y > 180)
		{
			Debug.Log("STOP");
		}
	}
}
