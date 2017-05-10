using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extrovert : MonoBehaviour {

	public CircleSpace myCircleSpace;
	public GameManagerScript myGameManager;
	public ColorManager myColorManager;


	public int maxEntities;
	public int minEntities;

	int currentMaxEntities;
	int currentMinEntities;

	public bool amIhappy;

	Transform myRing;


	void Start() {
		myRing = gameObject.GetComponentInChildren<Transform> ();
		currentMaxEntities = maxEntities;
		currentMinEntities = minEntities;
		happyChecker ();
	}

	public void happyChecker ()
	{

		//myGameManager.happyGuests.Clear ();
		//myGameManager.unHappyGuests.Clear ();

		if (myCircleSpace.entities.Count > currentMaxEntities || myCircleSpace.entities.Count < currentMinEntities)
		{

			amIhappy = false;
			myColorManager.UnhappyAnimation (); //unHappy
			myGameManager.addToList(gameObject, amIhappy);
		}
		else if (myCircleSpace.entities.Count <= currentMaxEntities && myCircleSpace.entities.Count >= currentMinEntities)
		{

			amIhappy = true;
			myColorManager.HappyAnimation (); //happy
			myGameManager.addToList(gameObject, amIhappy);
		}

		//Debug.Log (amIhappy);
	}

	public void changeParams ()
	{
		currentMaxEntities = maxEntities + 1;
		currentMinEntities = minEntities - 1;
		myRing.localScale = new Vector3 (1.5f, 1, 1.5f);

	}

	public void revertParams ()
	{
		currentMaxEntities = maxEntities - 1;
		currentMinEntities = maxEntities + 1;
		myRing.localScale = new Vector3 (1, 1, 1);

	}

}
