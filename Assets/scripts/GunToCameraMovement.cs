using UnityEngine;
using System.Collections;

public class GunToCameraMovement : MonoBehaviour {
	
	private Camera cameraToFollow;
	public Transform weapon;
	public float speed = 25.0f;

	// Use this for initialization
	void Start () {
	
		this.cameraToFollow = Camera.main;
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		Vector3 eulerRotationTo = this.cameraToFollow.transform.rotation.eulerAngles;
		eulerRotationTo.y += 180.0f;
		eulerRotationTo.x = -eulerRotationTo.x;
		Quaternion rotationTo = Quaternion.Euler(eulerRotationTo);
		this.weapon.transform.rotation = Quaternion.Lerp(this.weapon.transform.rotation, rotationTo, 0.5f*Time.deltaTime*this.speed);
	}
}
