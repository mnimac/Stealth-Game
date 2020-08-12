using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public event System.Action OnReachedEnd;
	
    public float moveSpeed = 7;
    public float smoothMoveTime = .1f;
	public float turnSpeed = 8;

	float angle;
	float smoothInputMagnitude;
	float smoothMoveVelocity;
    Vector3 velocity;

//adding rigidbody
    Rigidbody rigidbody;

	bool disabled;

    void Start() {
		rigidbody = GetComponent<Rigidbody> ();

		Guard.OnGuardHasSpottedPlayer += Disable;
	}

//moving the player
    void Update () {
		//disabling movement when spotted
		Vector3 inputDirection = Vector3.zero;
		if (!disabled) {
			inputDirection = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
		}
        float inputMagnitude = inputDirection.magnitude;
		smoothInputMagnitude = Mathf.SmoothDamp (smoothInputMagnitude, inputMagnitude, ref smoothMoveVelocity, smoothMoveTime);

		float targetAngle = Mathf.Atan2 (inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
		angle = Mathf.LerpAngle (angle, targetAngle, Time.deltaTime * turnSpeed * inputMagnitude);

		velocity = transform.forward * moveSpeed * smoothInputMagnitude;
    }

	void OnTriggerEnter(Collider hitCollider) {
		if(hitCollider.tag == "Finish") {
			Disable();
			if (OnReachedEnd != null)
				OnReachedEnd();
		}
	}

	void Disable(){
		disabled = true;
	}

//on colision player rotation
    void FixedUpdate() {
		rigidbody.MoveRotation (Quaternion.Euler (Vector3.up * angle));
		rigidbody.MovePosition (rigidbody.position + velocity * Time.deltaTime);
	}

	void OnDestroy(){
		Guard.OnGuardHasSpottedPlayer -= Disable;
	}
}
