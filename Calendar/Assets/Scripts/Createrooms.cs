using UnityEngine;
using System.Collections;
// Use this for initialization
public class Createrooms : MonoBehaviour {
	public GameObject room;
	GameObject[,] rooms;
	int width = 20,height = 20;
	int roomcountercreationx = 0;
	int roomcountercreationy = 0;
	int row = 0;
	void Start () {
		rooms = new GameObject[width,height];
	}

	// Update is called once per frame
	void Update () {
		roomcountercreationx++;
		if (roomcountercreationx + roomcountercreationy > row) {
			roomcountercreationy--;
			if(
		}
		rooms[roomcountercreationx,roomcountercreationy] = Instantiate(room, new Vector3(roomcountercreationx * 2.0F, 0.5f, roomcountercreationy * 2.0f), Quaternion.identity) as GameObject;
	}
}