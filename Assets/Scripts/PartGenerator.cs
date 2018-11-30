using UnityEngine;
using Lean.Touch;
public class PartGenerator : MonoBehaviour
{

	public Transform[] partPrefabs;
	public GameObject spawnerPrefab;
	public Transform currentContraption;

	public void Awake() {
		foreach (Transform part in partPrefabs) {
			GameObject instance = Instantiate(spawnerPrefab);

			instance.GetComponent<SpawnPart>().partPrefab = part.gameObject;

			instance.transform.SetParent(transform);
		}
	}
	
	public void SetContraption(Transform contraption) {
		this.currentContraption = contraption;
	}
}