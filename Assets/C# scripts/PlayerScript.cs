using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	public GameObject Player = null;

	enum PlayerState : short {ATK , NUET , DEF};
	void Update () 
	{
		if (Input.GetKey(KeyCode.RightArrow)) 
		{
			transform.Translate(Vector3.right * 3.0f * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.LeftArrow)) 
		{
			transform.Translate(Vector3.right * -3.0f * Time.deltaTime);
		}
	}
}
