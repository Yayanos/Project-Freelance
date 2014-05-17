using UnityEngine;
using System.Collections;

public class lightScript : MonoBehaviour {
	
	public float scaleAmount = 20f;
	public float scaleIntensityAmount = 3.5f;
	
	public float interval = 0.01f;
	

	private float lastTime = 0;
	
	public Vector2 rangeLength = new Vector2(10 , 20);

	// Update is called once per frame
	private void Update () {
	if (lastTime + interval <= Time.time){
			lastTime = Time.time;
			gameObject.light.range = Random.Range(0 , scaleAmount);
			gameObject.light.intensity = Random.Range(0 , scaleIntensityAmount);
		}
	}
}
