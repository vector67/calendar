using UnityEngine;
using System.Collections;
using System.Globalization;
using System;

public class Day {
	private DateTime day;
	private GameObject worldrep;

	public Day(DateTime day,GameObject worldrep){
		this.day = day;
		this.worldrep = worldrep;
	}

	public DateTime GetDay(){
		return day;
	}

	public GameObject GetWorldRepresentation(){
		return this.worldrep;
	}
}
