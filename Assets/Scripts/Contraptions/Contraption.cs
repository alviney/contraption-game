using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class Contraption : MonoBehaviour {

	public ContraptionManager ContraptionManager;
	public bool editing = true;
	public bool isSelected = false;
	// public Part selectedPart;
	public List<Part> selectedParts;

	public void Select(Part part) 
	{
		if (!selectedParts.Contains(part)) 
			selectedParts.Add(part);
	}

	public void DeselectSelectedParts() 
	{
		foreach(Part part in selectedParts) 
			part.Deselect();
	}

	public void SnapSelectedParts() 
	{
		foreach(Part part in selectedParts)
			part.Snap();
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);
		
		Gizmos.color = Color.blue;
		Vector2 center = GetCenter();
		Gizmos.DrawSphere(new Vector3(center.x, center.y, 0), 1f);
	}

	public Vector2 GetCenter() {
		float totalX = 0f;
		float totalY = 0f;
		foreach(Transform part in transform) {
			totalX += part.transform.position.x;
			totalY += part.transform.position.y;
		}

		float centerX = totalX / transform.childCount;
		float centerY = totalY / transform.childCount;

		return new Vector2(centerX, centerY);
	}

	public void CenterParts() {
		Vector2 center = GetCenter();
		Vector2 offset = new Vector2(transform.position.x, transform.position.y) - center;
		foreach(Transform part in transform) {
			part.position += new Vector3(offset.x, offset.y, 0);
		}
		transform.position = center;
	}

	public void Build() {
		StopEditing();
	}

	public void Deselect() {
		isSelected = false;
	}

	public void Destroy() {
		Destroy(this);
	}

	public void StartEditing() {
		editing = true;
		foreach(Transform child in transform) {
			child.GetComponent<SnapToGrid>().snap = true;
		}
	}

	public void StopEditing() {
		editing = false;

		CenterParts();
		
		// Disable Snapping of parts
		foreach(Transform child in transform) {
			child.GetComponent<SnapToGrid>().snap = false;
		}
	}
}
