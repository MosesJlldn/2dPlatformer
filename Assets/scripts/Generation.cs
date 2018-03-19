using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Generation : MonoBehaviour {

	public Transform v1;
	public Transform v2;
	public GameObject parent;
	public GameObject go;
	public float roughness;
	private ArrayList points;

	// Use this for initialization
	void Start () {
		
		points = new ArrayList ();
		DiamondSquareAlg.calculate (v1.position, v2.position, roughness, points);

		foreach (Vector2 point in points) {
		
			Instantiate (go, new Vector3 (point.x, point.y, 0), Quaternion.identity, parent.transform); 
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
