using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManagerScript : MonoBehaviour
{

	public Introvert myIntrovert;
	public Extrovert myExtrovert;
    public UImanager myUImanager;
    public List<GameObject> happyGuests = new List<GameObject>();
	public List<GameObject> unHappyGuests = new List<GameObject>();

	private WinConditions myWinConditions;
    
	GameObject[] getAll;
	Drag myDrag;
    CircleSpace myCircleSpace;
	//public GameObject youWin;
	//public GameObject Next;
	//public GameObject Quit1;

	void Start (){
		


	}


	public void addToList(GameObject receivedEntity, bool isThisEntityHappy)
	{
		if (!isThisEntityHappy) {
			if (!unHappyGuests.Contains(receivedEntity)) {
				unHappyGuests.Add(receivedEntity);
			}
			if (happyGuests.Contains (receivedEntity)) {
				happyGuests.Remove(receivedEntity);
			}
		}
		if (isThisEntityHappy) {
			if (!happyGuests.Contains (receivedEntity)) {
				happyGuests.Add (receivedEntity);
			} 
			if (unHappyGuests.Contains (receivedEntity)) {
				unHappyGuests.Remove (receivedEntity);
			}
		}
	}


	void Update (){

		if (unHappyGuests.Count == 0) {
			Debug.Log ("YOU WIN");

			//Display YOU WIN text and next quit buttons
			//myUImanager.youWin.SetActive (true);
			//Next.SetActive (true);
			//Quit1.SetActive (true);

			if (getAll == null)
				getAll = GameObject.FindGameObjectsWithTag ("Character");
			foreach (GameObject entity in getAll) {
				entity.GetComponent<Drag>().enabled = false;
			}

		}

	}

}
