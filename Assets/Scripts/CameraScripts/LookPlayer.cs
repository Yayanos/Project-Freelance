using UnityEngine;
using System.Collections;

public class LookPlayer : MonoBehaviour 
{
	public Transform target;
	public float minHeight 	   = 100;
	public float maxHeight     = 150;
	public float currentHeight = 100;
	
	private bool zoom = false;
	
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(target)
		{
			transform.position = new Vector3(target.position.x, currentHeight, target.position.z);
		}
		
		if (!target)
		{
			target = GameObject.FindWithTag("Player").transform;	
		}
		
		if(Input.GetKey(KeyCode.LeftShift))
		{
			zoom = true;	
		}
		else
		{
			zoom = false;
		}
		
		if(zoom)
		{
			currentHeight = maxHeight;
		}
		
		else
		{
			currentHeight = minHeight;	
		}
	}
}
