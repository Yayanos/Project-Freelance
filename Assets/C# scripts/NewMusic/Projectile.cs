using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	
	public GameObject destroy = null;
	private void OnCollisionEnter2D(Collider2D c)
	{
		Destroy(gameObject);
	}
}
