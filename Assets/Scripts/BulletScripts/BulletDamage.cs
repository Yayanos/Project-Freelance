using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour 
{
	public int Power = 5;
	
	public GameObject explosion;
	public AudioClip explosionSound;
	
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject)
		{
			other.gameObject.SendMessage("Damage",Power,SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
			
			GameObject clone;
			clone = Instantiate(explosion, transform.position,transform.rotation) as GameObject;
			AudioSource.PlayClipAtPoint(explosionSound,transform.position);
			
			
			
			Destroy(gameObject);
		}
	}
	
	
	
	
	
}
