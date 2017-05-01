using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpace : MonoBehaviour
{
    public List<GameObject> entities = new List<GameObject>();

    void OnTriggerEnter(Collider receivedEntity)
    {
		if (receivedEntity.gameObject.tag == "Character")
		{
			if (!entities.Contains(receivedEntity.gameObject)) {
				entities.Add(receivedEntity.gameObject);
				SendMessage ("happyChecker");
                
			}
		}
		if (receivedEntity.gameObject.tag == "Environment")
		{
            SendMessage ("changeParams");
        }
    }

	void OnTriggerExit(Collider receivedEntity)
    {
		if (receivedEntity.gameObject.tag == "Character") {
			if (entities.Contains (receivedEntity.gameObject)) {
				entities.Remove (receivedEntity.gameObject);
				SendMessage ("happyChecker");
			}
		}
		if (receivedEntity.gameObject.tag == "Environment")
		{
			SendMessage ("revertParams");
		}
    }
}