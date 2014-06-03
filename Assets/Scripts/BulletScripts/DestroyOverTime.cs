using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour 
{
	public float timer = 1;

	void Awake()
	{
		Destroy(gameObject, timer);
	}
		
	
	
}
