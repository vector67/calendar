using UnityEngine;
using System.Collections;

public class Bymonths : MonoBehaviour {
	public Dayorganizer d;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void rearrangebymonths () {
		d.rearrange (2);
	}
}