using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour 
{
	public int score = 0;
	
	public float x = 0;
	public float y = 0;
	public float width = 20;
	public float height = 20;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnGUI()
	{
		GUI.Label(new Rect(20,20,200,20),"Score: " + score);
	}
	
}
