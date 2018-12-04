using UnityEngine;
using Lean.Touch;
public class PartGenerator : MonoBehaviour
{	
	public GameObject[] parts;
	public GameObject spawnerPrefab;
	public Transform currentContraption;

	public void Awake() {
		
		foreach (GameObject part in parts) {
			GameObject instance = Instantiate(spawnerPrefab);

			SpawnPart spawner = instance.GetComponent<SpawnPart>();

			spawner.part = part;

			instance.transform.SetParent(transform);
		}
	}
	
	public void SetContraption(Transform contraption) {
		this.currentContraption = contraption;
	}
}