using UnityEngine;
using System.Collections;

public class PointerScript : MonoBehaviour 
{
	public GameObject pointerPrefab;
	public float cursorDistance	= 50;
	
	private GameObject pointerClone;
	
	// Use this for initialization
	void Start () 
	{
		Screen.showCursor = false;
	}
	
	public Vector3 GetMouseTarget()
	{
		Ray ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
		return ray.GetPoint(cursorDistance);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 destination = GetMouseTarget();
		
		if (pointerClone == null)
		{
			pointerClone = Instantiate(pointerPrefab, destination, Quaternion.identity) as GameObject;
		}
		else
		{
			pointerClone.transform.position = destination;	
		}
	}
}
