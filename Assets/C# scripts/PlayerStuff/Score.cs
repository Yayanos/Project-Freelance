using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
    public int score = 0;

    public float x = 0;
    public float y = 0;
    public float width = 30;
    public float height = 30;

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
        GUI.Label(new Rect(20,30,200,20),"Score: " + score);
    }
}
