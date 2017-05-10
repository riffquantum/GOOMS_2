using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introvert : MonoBehaviour {
    
	public CircleSpace myCircleSpace;
    public GameManagerScript myGameManager;
	public ColorManager myColorManager; 


    public int maxEntities;
    public int minEntities;

	int currentMaxEntities;
	int currentMinEntities;

	Transform myRing;

	public bool amIhappy;

	void Start() {
		myRing = gameObject.GetComponentInChildren<Transform> ();
		Debug.Log (myRing);
		currentMaxEntities = maxEntities;
		currentMinEntities = minEntities;
		happyChecker ();
	}

    public void happyChecker ()
    {
		
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
