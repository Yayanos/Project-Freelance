using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour 
{
	public int health = 100;
	
	
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (health < 0)
		{
			Respawn();	
		}
	}
	
	public void Damage(int dmg)
	{
		health -= dmg;	
	}
	
	
	private void Respawn()
	{
		Transform spawnpoint = GameObject.FindWithTag("Spawnpoint").transform;
		
		transform.position = spawnpoint.position;
		health = 100;
		
	}
	
	
	
	
	
	
}
