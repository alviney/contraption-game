using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Lean.Touch;

[Serializable]
public class ContraptionManager: MonoBehaviour {

	public GameObject contraptionPrefab;
	public GameObject contraptionSpawn;
	public GameObject UI_slots;
	public PartGenerator PartGenerator;
	public List<Transform> contraptions;
	private int numOfSlots;
	private Contraption currentContraption;
	private int contraptionIndex = -1;

	public void Setup(int numOfSlots) {

		this.numOfSlots = numOfSlots;
	}

	public void CreateContraption() {
		Debug.Log("CREATE CONTRAPTION");

		if (contraptions.Count > numOfSlots - 1) return;

		GameObject instance = Instantiate(contraptionPrefab);

		instance.transform.SetParent(transform);

		PartGenerator.SetContraption(instance.transform);

		currentContraption = instance.GetComponent<Contraption>();

		currentContraption.ContraptionManager = this;

	}

	public void DeleteContraption() {
		currentContraption.Destroy();
	}

	public void BuildContraption() {
		Debug.Log("BUILD CONTRAPTION");

		currentContraption.Build();

		contraptions.Add(currentContraption.transform);

		contraptionIndex++;
	}

	public void EditContraption() {
		Debug.Log("BEGIN EDITING CONTRAPTION");
		currentContraption.StartEditing();
	}

	public void FinishEditing() {
		currentContraption.StopEditing();
	}

	public void CancelEditing() {
		Debug.Log("CANCEL EDITING CONTRAPTION");
		// TODO - Reset GameObject to state before editing started.
		currentContraption.StopEditing();
	}

	public void SelectContraption(Contraption contraption) {
		Debug.Log("SELECT CONTRAPTION");
		currentContraption = contraption;
		
		foreach(Transform child in contraptions) {
			child.gameObject.GetComponent<Contraption>().Deselect();
		}
	}

	public Contraption GetCurrentContraption() {
		return currentContraption;
	}

	// public void AddContraptionSpawner(int contraptionIndex) {
	// 		Transform slot = UI_slots.transform.GetChild(contraptionIndex);

	// 		slot.gameObject.SetActive(true);

	// 		ContraptionPlacer cp = slot.GetComponent<ContraptionPlacer>();

	// 		cp.constructed = currentContraptionGO;
	// }

	public void ReleaseContraptions() {
		foreach(Transform contraption in contraptions) {
			contraption.gameObject.AddComponent<Rigidbody2D>();
		}
	}

}
