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
	public GameObject character;
	private GameObject last_ground;
	public GameObject Player;
	private List<Transform> allgrounds;

	// Use this for initialization
	void Start () {
		
		allgrounds = new List<Transform> ();
		createPlatforms ();
	}

	// Update is called once per frame
	void Update () {

		float distance = character.transform.position.x - v1.position.x;

		if (distance > 7) {

			Vector3 pos = v2.position + new Vector3 (32, 0, 0);
			v1 = v2;
			GameObject new_go = Instantiate (go, pos, Quaternion.identity) as GameObject;
			v2 = new_go.transform;
			createPlatforms ();
		}

		Vector2 char_pos = character.transform.position;

		foreach (Transform ground in allgrounds) {
				
			if (Vector2.Distance (char_pos, new Vector2 (ground.position.x, ground.position.y)) > 10) {
				ground.gameObject.SetActive (false);
			} else {
				ground.gameObject.SetActive (true);
			}
		}
	}

	void createPlatforms () {

		List<Vector2> points = new List <Vector2>();
		DiamondSquareAlg.calculate (v1.position, v2.position, roughness, points);
		points.Sort ((p1, p2) => p1.x.CompareTo(p2.x));

		foreach (Vector2 point in points) {

			GameObject o;
			o = Instantiate (go, new Vector3 (point.x, point.y), Quaternion.identity, transform);
			allgrounds.Add (o.transform);
		}
	}
}
