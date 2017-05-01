using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;

	public LayerMask backgroundLayerMask;
	public float dragFollowSpeed;

	Rigidbody myRigidbody;

	void Start() {
		myRigidbody = GetComponent<Rigidbody> ();
	}

	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(transform.position);
		offset =  transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,screenPoint.z));
	}

	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

		RaycastHit raycastHit;
		Physics.Raycast(transform.position, (curPosition - new Vector3(transform.position.x, transform.position.y, transform.position.z)).normalized, out raycastHit, (curPosition - new Vector3(transform.position.x, transform.position.y, transform.position.z)).magnitude, backgroundLayerMask);
		Vector3 destination = curPosition;
		if (raycastHit.collider != null) {
			destination = raycastHit.point;
			Debug.Log (raycastHit.collider.gameObject);
		}
		myRigidbody.MovePosition(Vector3.Lerp(transform.position, destination, Time.deltaTime * dragFollowSpeed));

		//draggedObject.transform.position = inputPosition;// + touchOffset;
		//transform.position = curPosition;
	}
}