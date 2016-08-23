using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public GameObject prefab;

	public float ProjectleSpeed;

	public void Shoot (Ray ray) {
		GameObject gameObject = Instantiate (prefab, transform.position, transform.rotation) as GameObject;

		Projectile projectile = gameObject.GetComponent<Projectile> ();
		projectile.Velocity = ray.direction * ProjectleSpeed;
	}
}
