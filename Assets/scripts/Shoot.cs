using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	
	public Texture2D pointerTexture;
	public GameObject bulletPrefab;
	public Transform shootPoint;
	public float shootForce = 10.0f;
	public int shotsPerSecond = 1;
	double timeSinceLastShoot = 0.0;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if (Input.GetMouseButtonDown (0)) {
		this.timeSinceLastShoot += Time.deltaTime;
		if (Input.GetButton ("Fire1")) {
			
			if (Input.GetButtonDown("Fire1") || (this.timeSinceLastShoot >= (1.0 / this.shotsPerSecond))) {
				this.timeSinceLastShoot = 0.0;
				Vector3 pos = this.shootPoint.position;
				Vector3 direction = Camera.main.transform.forward;
				GameObject bullet = (GameObject)Instantiate (this.bulletPrefab, pos, Camera.main.transform.rotation);
				bullet.rigidbody.AddForce (direction * this.shootForce, ForceMode.Impulse);
			}
			
			
		}
	}
	
	void OnGUI ()
	{
		Rect pointerRect = new Rect (((Screen.width - this.pointerTexture.width) / 2.0f), ((Screen.height - this.pointerTexture.height) / 2.0f), this.pointerTexture.width, this.pointerTexture.height);
		GUI.DrawTexture (pointerRect, this.pointerTexture);
	}
}
