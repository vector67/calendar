using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System;

public class Dayorganizer : MonoBehaviour {
	private int type = 0; // 0=days, 1=weeks, 2=months, 3=years || default is days
	Dictionary<string, int> Daysbyname = new Dictionary<string, int>() { {"Monday",0}, {"Tuesday", 1},{"Wednesday",2},{"Thursday",3},{"Friday",4},{"Saturday",5},{"Sunday",6} }; 
	private bool rearranged = true;
	private int placeinrow,placeincolumn;
	private int currentday = 0;
	private int rowwidth = 0;
	public Day[] days;
	GregorianCalendar gc;
	DateTime today;
	// Use this for initialization
	void Start () {
		rearrange (0);
		gc = new GregorianCalendar ();
	}
	
	// Update is called once per frame
	void Update () {
		if (days == null) {
			days = gameObject.GetComponent<Createrooms> ().days;
		}
		/*if (!rearranged) {
			days [roomcountercreationx*height+roomcountercreationy] = Instantiate (room, new Vector3 (roomcountercreationx * 2.0F, 0.5f, roomcountercreationy * 2.0f), Quaternion.identity) as GameObject;
			roomcountercreationx++;
			roomcountercreationy--;
			if (roomcountercreationy < 0 || roomcountercreationx > width - 1) {
				row++;
				roomcountercreationy = Mathf.Min (row, height - 1); //height-1 because row is 0 based and height is 1 based
				roomcountercreationx = row - roomcountercreationy;
				if (row >= width + height - 1) {
					done = true;
					return;
				}
			}
		}*/
		for (int i = 0; i<800/(1/Time.fixedDeltaTime); i++) {

			if (!rearranged) {
				switch (type) {
				case 0: //Days
					if (rowwidth == 0) {
						placeinrow = 0;
						placeincolumn++;
						rowwidth = days.Length + 1; // The days are arranged in one line, so the width is as long as however many days there are.
					}
					break;
				case 1: //Weeks
					if (rowwidth == 0 || placeinrow == rowwidth+1) {
						print(Daysbyname[gc.GetDayOfWeek (days[0].GetDay ()).ToString ()]);
						placeinrow = (currentday==0)?Daysbyname[gc.GetDayOfWeek (days[0].GetDay ()).ToString ()]:0;
						placeincolumn++;
						rowwidth = 7;
					}
					break;
				case 2: //Months
					if (rowwidth == 0 || placeinrow == rowwidth+1) {
						placeinrow = ((currentday==0)?gc.GetDayOfMonth (days[0].GetDay ()):0);
						placeincolumn++;
						rowwidth = gc.GetDaysInMonth (days [currentday].GetDay ().Year, days [currentday].GetDay ().Month);
					}
					break;
				case 3://Years
					if (rowwidth == 0 || placeinrow == rowwidth+1) {
						placeinrow = 0;//((currentday==0)?gc.GetDayOfYear (days[0].GetDay ()):0);
						placeincolumn++;
						rowwidth = gc.GetDaysInYear (days [currentday].GetDay ().Year);
					}
					break;
				default:
					break;
				}
				iTween.MoveTo (days [currentday].GetWorldRepresentation (), new Vector3 (placeinrow* 2.0F, 0.5f, -placeincolumn * 2.0f), 1);
				currentday++;
				placeinrow++;
				if (currentday >= days.Length) {
					rearranged = true;
					rowwidth = 0;
					return;
				}

			} 
		}
	}

	public void rearrange(int type){
		this.type = type;
		rearranged = false;
		rowwidth = 0;
		currentday = 0;
		placeinrow = 0;
		placeincolumn = 0;
	}
}
