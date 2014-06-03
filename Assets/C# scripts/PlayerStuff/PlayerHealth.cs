using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
    public int maxHealth = 100;
    public int curHealth = 100;
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
        GUI.Box(new Rect(10, 10, Screen.width / 2 / (maxHealth / curHealth), 20), curHealth + "/" + maxHealth);
    }
}
