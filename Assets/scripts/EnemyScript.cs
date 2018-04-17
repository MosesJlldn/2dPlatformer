using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : PhysicsObject {

	private Transform target;
	private GameObject player;
	public float speed;
	public float attackRange;
	public float viewRange;

	delegate void EnemyState();
	EnemyState combatState;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		target = player.transform;
		combatState = Search;
	}
	
	// Update is called once per frame
	void Update () {
		
		combatState ();
	}

	void Attack () {
		Debug.Log ("Attack");
		if (Vector3.Distance (target.position, transform.position) > attackRange) {
			
			combatState = Search;
		}
	}

	void Search () {
		Debug.Log ("Search");
		if (Vector3.Distance (target.position, transform.position) < viewRange) {

			combatState = Move;
		}
	}

	void Move () {
		Debug.Log ("Move");
		if (target.position.x < transform.position.x) {
			Debug.Log ("+");
			GetComponent<SpriteRenderer> ().flipX = true;
			transform.position -= new Vector3 (speed * Time.deltaTime, 0);
		} else {
			Debug.Log ("+");
			GetComponent<SpriteRenderer> ().flipX = false;
			transform.position += new Vector3 (speed * Time.deltaTime, 0);
		}

		if (Vector3.Distance (transform.position, target.position) < attackRange) {

			combatState = Attack;
		} 
	}
}
