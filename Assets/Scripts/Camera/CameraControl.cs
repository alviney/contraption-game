using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	public float zoomMin = 10;
	public float zoomMax = 20;
	private Camera camera;
	private ContraptionManager ContraptionManager;

	private Vector3 startingPos;

	private void Awake() {
		camera = GetComponent<Camera>();

		startingPos = transform.position;

		ContraptionManager = GameObject.Find("CONTRAPTIONS").GetComponent<ContraptionManager>();

		ZoomOut();
	}

	public void ZoomToggle() {
		camera.orthographicSize = camera.orthographicSize == zoomMax ? zoomMin : zoomMax; 	
	}

	public void ZoomIn() {
		camera.orthographicSize = zoomMin;
	}

	public void ZoomOut() {
		camera.orthographicSize = zoomMax;
	}

	public void FocusOnCurrentContraption() {
		Vector3 targetPos = ContraptionManager.GetCurrentContraption().transform.position;
		transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);
		ZoomIn();
	}

	public void MoveToStartingPosition() {
		transform.position = startingPos;
	}
}
