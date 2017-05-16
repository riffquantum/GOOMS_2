using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpace : MonoBehaviour
{
    public List<GameObject> entities = new List<GameObject>();
    


    void Start()
    {
        
    }
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
            SendMessage ("enterZoneParams");
        }
        if (receivedEntity.gameObject.tag == "Friend")
        {
            SendMessage("withFriendParams");
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
			SendMessage ("leaveZoneParams");
		}
        if (receivedEntity.gameObject.tag == "Friend")
        {
            SendMessage("withoutFriendParams");
        }

    }
}