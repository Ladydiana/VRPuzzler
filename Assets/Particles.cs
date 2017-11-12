using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour {

	public GameObject poof;


	public void particleOn() {
		Object.Instantiate (poof, transform.position, Quaternion.Euler (-90, 0, 0));

	}
}
