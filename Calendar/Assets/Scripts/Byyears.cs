using UnityEngine;
using System.Collections;

public class Byyears : MonoBehaviour {
	public Dayorganizer d;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void rearrangebyyears () {
		d.rearrange (3);
	}
}