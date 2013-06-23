using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	
	public Texture2D pointerTexture;
	
	GameObject weaponGO;
	Weapon weaponScript;

	// Use this for initialization
	void Start ()
	{
		foreach (Transform child in this.transform)
		{
			if (child.gameObject.tag == "weapon")
			{
				this.weaponGO = child.gameObject;
				break;
			}
		}
		if (this.weaponGO != null)
		{
			this.weaponScript = this.weaponGO.GetComponent<Weapon>();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButton ("Fire1")) {
			if (this.weaponScript != null)
			{
				this.weaponScript.TryToShoot(Input.GetButtonDown("Fire1"));
			}
		}
	}
	
	void OnGUI ()
	{
		Rect pointerRect = new Rect (((Screen.width - this.pointerTexture.width) / 2.0f), ((Screen.height - this.pointerTexture.height) / 2.0f), this.pointerTexture.width, this.pointerTexture.height);
		GUI.DrawTexture (pointerRect, this.pointerTexture);
	}
}
