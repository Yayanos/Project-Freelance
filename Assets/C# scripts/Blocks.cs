using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour {

	public float waitTime = 0.5f;

	IEnumerator StartFall()
	{
		yield return new WaitForSeconds(waitTime);
		gameObject.AddComponent<Rigidbody>();
	}

	void OnCollisionEnter(Collision c)
	{
		if (rigidbody == null && c.transform.tag == "Player") 
			StartCoroutine(StartFall());
	}
}