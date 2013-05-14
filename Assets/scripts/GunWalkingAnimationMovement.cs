using UnityEngine;
using System.Collections;

public class GunWalkingAnimationMovement : MonoBehaviour
{
	
	public Transform player;
	private float _x;
	private float _y;
	
	// Use this for initialization
	void Start ()
	{
		_x = 0.0f;
		_y = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void LateUpdate ()
	{
		
		Vector3 pos = this.player.position;
		pos += (this.player.rotation * new Vector3 (0.4f, 1.46f, 0.3f));
		
		float movementVertical = Input.GetAxis ("Vertical");
		float movementHorizontal = Input.GetAxis ("Horizontal");
		
		if (Mathf.Abs (movementVertical) > 0.3f || Mathf.Abs (movementHorizontal) > 0.3f) {
			
			float velocity = 0.025f;
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				velocity *= 2.0f;
			}
			
			float offsetX = (Mathf.Sin (_x * 8.0f) * velocity);
			float offsetY = (Mathf.Cos (_y * 16.0f) * velocity);
		
			pos.x += offsetX;
			pos.y += offsetY;
		
			_x += Time.deltaTime;
			_y += Time.deltaTime;
		}
		
		this.transform.position = pos;
	}
}
