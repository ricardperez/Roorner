using UnityEngine;
using System.Collections;

public class ParticlesKiller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!this.particleSystem.IsAlive())
		{
			Destroy (this.gameObject);
		}
	}
}
