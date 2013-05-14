using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	
	private float _velocity;
	public Texture2D decal;
	public Transform explosionPrefab;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
//		Vector3 pos = this.transform.position;
//		pos += (this.transform.forward * this._velocity * Time.deltaTime);
//		this.transform.position = pos;
	}
	
	public void setVelocity (float velocity)
	{
		this._velocity = velocity;
	}
	
	public float getVelocity ()
	{
		return this._velocity;
	}
	
	void OnTriggerEnter (Collider other)
	{
//		if (_alreadyBounced)
//		{
//			return;
//		}
//		if ((other.tag == "wall") || (other.tag == "separator") || (other.tag == "floor")) {
//			_alreadyBounced = true;
//			//ray tracing
//			Vector3 direction = this.transform.forward.normalized;
//			Vector3 origin = (this.transform.position - 2 * direction);
//			Debug.DrawLine (origin, origin + 5 * direction, Color.green, 3.0f);
//			RaycastHit[] hitsInfo = Physics.RaycastAll (origin, direction, 3.0f);
//			
//			foreach (RaycastHit hitInfo in hitsInfo) {
//				if (hitInfo.collider == other) {
//					Vector3 normal = hitInfo.normal.normalized;
//					float cosAngle = Vector3.Dot (normal, direction);
//					Vector3 newDirection = (direction + 2 * Vector3.Cross(Vector3.Cross(direction, normal), normal));
//					Debug.Log("Normal: " + normal + "  -  direction: " + direction + "  -  new direction: " + newDirection);
//					this.transform.rotation = Quaternion.LookRotation (newDirection);
//					break;
//				}
//			}
//		}
	}
	
	void OnCollisionEnter (Collision collision)
	{
//		if (collision.gameObject.tag == "map-walls") {
//			RaycastHit hit = new RaycastHit ();
//			Ray ray = new Ray (collision.contacts [0].point + collision.contacts [0].normal, -collision.contacts [0].normal);
//			
//			Debug.DrawRay (ray.origin, ray.direction, Color.green, 5.0f);
//			if (Physics.Raycast (ray, out hit)) {
//				
//				Vector3 uvCoordinates = hit.textureCoord;
//				uvCoordinates.x = 1.0f - uvCoordinates.x;
//				Debug.Log ("UV Coordinates: " + uvCoordinates);
//				
//				if (collision.gameObject.renderer.material.mainTexture == null) {
//					Texture2D text = new Texture2D (100, 100);
//					collision.gameObject.renderer.material.mainTexture = text;
//				}
//				Texture2D currTexture = (Texture2D)collision.gameObject.renderer.material.mainTexture;
//				
//				int width = this.decal.width;
//				int height = this.decal.height;
//				
//				int startY = Mathf.Max (0, (((int)(uvCoordinates.y * currTexture.width)) - height / 2));
//				int startX = Mathf.Max (0, (((int)(uvCoordinates.x * currTexture.height)) - width / 2));
//				
//				width = Mathf.Min (width, currTexture.width - startX - 1);
//				height = Mathf.Min (height, currTexture.height - startY - 1);
//				
//				Color[] pix = this.decal.GetPixels (0, 0, width, height);
//				currTexture.SetPixels (startX, startY, width, height, pix);
//				currTexture.Apply ();
//				
//			} else {
//				Debug.Log ("No hitting??");
//			}
//			
//		}
		
		if (collision.gameObject.tag == "enemy")
		{
			EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
			enemyController.applyDamage(20);
		}

		Instantiate (this.explosionPrefab, this.transform.position, Quaternion.identity);
		Destroy (this.gameObject);
	
	}
}
