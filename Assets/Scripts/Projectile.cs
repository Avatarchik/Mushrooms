using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Vector3 Velocity;

	public float ExplosionRadius = 2f;

	public float ExplosionForce = 10f;

	public float LifeTime = 3f;

	public Rigidbody _Body;

	void Start () {
		Destroy (gameObject, LifeTime);

		_Body.velocity = Velocity;
	}

	// Update is called once per frame
	void FixedUpdate () {
		
	}

	void OnTriggerEnter(Collider collider) {
		Explode ();
	}

	void Explode() {
		Collider[] colliders = Physics.OverlapSphere (transform.position, ExplosionRadius);

		foreach (Collider collider in colliders) {
			Rigidbody rigidbody = collider.GetComponent<Rigidbody> ();

			if (rigidbody) {
				rigidbody.AddExplosionForce (ExplosionForce, transform.position, ExplosionRadius);
			}
		}

		Debug.Log ("Boom!");

		Destroy (gameObject);
	}
}
