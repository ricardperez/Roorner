using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {
	
	public float movementSpeed = 10.0f;
	public float rotationSpeedX = 1.0f;
	public float rotationSpeedY = 2.0f;
	public float cameraXRange = 60.0f;
	
	public float jumpSpeed = 10.0f;
	public int maxJumps = 3;
	int nJumps = 0;
	
	CharacterController characterController;
	float cameraCurrRotationX = 0.0f;
	float gravitySpeed = 0.0f;
	
	// Use this for initialization
	void Start () {
		
		this.characterController = this.GetComponent<CharacterController>();
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		float rotationY = Input.GetAxis("Mouse X") * this.rotationSpeedY;
		this.transform.Rotate(0.0f, rotationY, 0.0f);
		
		float rotationX = Input.GetAxis("Mouse Y") * this.rotationSpeedX;
		cameraCurrRotationX = Mathf.Clamp(cameraCurrRotationX-rotationX, -cameraXRange, cameraXRange);
		Camera.main.transform.localRotation = Quaternion.Euler(cameraCurrRotationX, 0.0f, 0.0f);
		
		float movementVertical = Input.GetAxis("Vertical") * movementSpeed;
		float movementHorizontal = Input.GetAxis("Horizontal") * movementSpeed;
		
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
		
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			movementVertical *= 2.0f;
			movementHorizontal *= 2.0f;
		}
		
		if ((this.characterController.isGrounded || this.nJumps < this.maxJumps) && Input.GetButtonDown("Jump"))
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
}
