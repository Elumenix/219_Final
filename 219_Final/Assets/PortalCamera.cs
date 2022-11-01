using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

	public Transform playerCamera;
	public Transform otherPortal;
	public Transform otherCamera;
	
	// Update is called once per frame
	void LateUpdate ()
	{
		// Actual camera doesn't store any rotation information
		Quaternion playerCameraRotation = Quaternion.Euler(playerCamera.parent.parent.rotation.x,
			playerCamera.parent.rotation.y, playerCamera.parent.rotation.z);
		Vector3 playerPosition = new Vector3(playerCamera.parent.parent.position.x + 0.2f, playerCamera.parent.parent.position.y + 3.75f, playerCamera.parent.parent.position.z);
		
		Vector3 playerOffsetFromPortal = playerPosition - transform.position;
		otherCamera.transform.position = otherPortal.transform.position + playerOffsetFromPortal;
		otherCamera.transform.rotation =
			otherPortal.rotation * Quaternion.Inverse(transform.rotation) * playerCameraRotation;


		/*transform.position = portal.position + playerOffsetFromPortal;

		float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

		Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
		Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
		transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);*/
	}
}
