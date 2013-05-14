using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	CharacterController characterController;
	float gravitySpeed = 0.0f;
	public float jumpSpeed = 10.0f;
	public int maxJumps = 3;
	int nJumps = 0;
	
	public float movementSpeed = 10.0f;
	public float rotationSpeedX = 1.0f;
	public float rotationSpeedY = 2.0f;
	public float cameraXRange = 60.0f;
	
	
	float lastMovementVertical = 1.0f;
	float lastMovementHorizontal = 0.0f;
	
	public int life = 100;
	
	// Use this for initialization
	void Start () {
	
		this.characterController = this.GetComponent<CharacterController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float rotationY = Random.Range (-0.15f, 0.15f) * this.rotationSpeedY;
		this.transform.Rotate(0.0f, rotationY, 0.0f);
		
		if (Random.value > 0.99)
		{
			this.changeDirection();
		}
		
//		float rotationX = 0.0f * this.rotationSpeedX;
//		cameraCurrRotationX = Mathf.Clamp(cameraCurrRotationX-rotationX, -cameraXRange, cameraXRange);
//		Camera.main.transform.localRotation = Quaternion.Euler(cameraCurrRotationX, 0.0f, 0.0f);
		
		lastMovementVertical += (Random.Range(-0.5f, 0.5f) * Time.deltaTime);
		if (lastMovementVertical < -1.0f)
		{
			lastMovementVertical = -1.0f;
		} else if (lastMovementVertical > 1.0f)
		{
			lastMovementVertical = 1.0f;
		}
		
		lastMovementHorizontal += (Random.Range(-0.15f, 0.15f) * Time.deltaTime);
		if (lastMovementHorizontal < -1.0f)
		{
			lastMovementHorizontal = -1.0f;
		} else if (lastMovementHorizontal > 1.0f)
		{
			lastMovementHorizontal = 1.0f;
		}
	
		float movementVertical = lastMovementVertical * this.movementSpeed;
		float movementHorizontal = lastMovementHorizontal * this.movementSpeed;
		
		if (!this.characterController.isGrounded)
		{
			movementVertical *= 0.5f;
			movementHorizontal *= 0.5f;
			
			this.gravitySpeed += Physics.gravity.y * Time.deltaTime;
			if (this.nJumps == 0)
			{
				this.nJumps = 1;
			}
		}
		
//		bool sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
		bool sprint = false;
		if (sprint)
		{
			movementVertical *= 2.0f;
			movementHorizontal *= 2.0f;
		}
		
//		bool jump = Input.GetButtonDown("Jump");
		bool jump = false;
		if ((this.characterController.isGrounded || this.nJumps < this.maxJumps) && jump)
		{
			this.gravitySpeed = this.jumpSpeed;
			this.nJumps++;
		}
		Vector3 moveSpeed = this.transform.rotation * (new Vector3(movementHorizontal, this.gravitySpeed, movementVertical));
		this.characterController.Move(moveSpeed * Time.deltaTime);
		
	}
	
	void LateUpdate()
	{
		if (this.characterController.isGrounded)
		{
			this.gravitySpeed = 0.0f;
			this.nJumps = 0;
		}
	}
	
	
	void changeDirection()
	{
		this.transform.rotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f);
	}
	
	
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.gameObject.tag == "map-walls")
		{
			this.changeDirection();
		}
	}
	
	public void applyDamage(int damage)
	{
		this.life -= damage;
		if (this.life <= 0)
		{
			Destroy (this.gameObject);
		}
	}
}
