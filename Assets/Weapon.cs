using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	
	public GameObject bulletPrefab;
	public Transform shootPoint;
	public float shootForce = 10.0f;
	public int shotsPerSecond = 1;
	float timeSinceLastShoot = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.timeSinceLastShoot += Time.deltaTime;
	}
	
	public void TryToShoot()
	{
		this.TryToShoot(false);
	}
	
	public void TryToShoot(bool forceShoot)
	{
		if (forceShoot || (this.timeSinceLastShoot >= (1.0/this.shotsPerSecond)))
		{
			this.timeSinceLastShoot = 0.0f;
			Vector3 pos = this.shootPoint.position;
			Vector3 direction = -this.transform.forward;
			GameObject bullet = (GameObject)Instantiate (this.bulletPrefab, pos, Camera.main.transform.rotation);
			bullet.rigidbody.AddForce (direction * this.shootForce, ForceMode.Impulse);
		}
	}
}
