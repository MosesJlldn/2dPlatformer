using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

	public float maxSpeed = 7;
	public float jumpTakeOffSpeed = 7;

	private SpriteRenderer spriteRenderer;
	private Animator animator;

	private bool isMoving;
	private bool isJumping;

	// Use this for initialization
	void Awake () 
	{
		spriteRenderer = GetComponent<SpriteRenderer> (); 
		animator = GetComponent<Animator> ();
	}

	protected override void ComputeVelocity()
	{
		isMoving = false;
		isJumping = false;
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxis ("Horizontal");

		if (Input.GetButtonDown ("Jump") && grounded) {
			
			velocity.y = jumpTakeOffSpeed;
			isJumping = true;
		} else if (Input.GetButtonUp ("Jump")) 
		{ 
			if (velocity.y > 0) {
				velocity.y = velocity.y * 0.5f;
			}
		}

		bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.0f) : (move.x < 0.0f));

		if (flipSprite) {

			spriteRenderer.flipX = !spriteRenderer.flipX;
		}

		targetVelocity = move * maxSpeed;

		if (move.x != 0)
			isMoving = true;

		SendAnimInfo (move.x);
	}

	void SendAnimInfo (float x) 
	{
		animator.SetFloat ("XSpeed", x);
		animator.SetBool ("isMoving", isMoving);
		animator.SetBool ("isGrounded", grounded);
		animator.SetBool ("isJumping", isJumping);
	}
}