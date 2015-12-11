using UnityEngine;
using System.Collections;

public class Byweeks : MonoBehaviour {
	public Dayorganizer d;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void rearrangebyweeks () {
		d.rearrange (1);
	}
}