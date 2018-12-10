using UnityEngine;
using Lean.Touch;
public class Factory_PartGenerator
{
    private GameObject[] partPrefabs;
    private GameObject partSpawnerPrefab;
    private Transform spawnersParent;

    public Factory_PartGenerator(Transform spawnersParent, GameObject[] partPrefabs, GameObject partSpawnerPrefab)
    {
        this.spawnersParent = spawnersParent;

        this.partPrefabs = partPrefabs;

        this.partSpawnerPrefab = partSpawnerPrefab;

        SpawnPartMakers();
    }

    private void SpawnPartMakers()
    {
        foreach (GameObject partPrefab in partPrefabs)
        {
            GameObject instance = MonoBehaviour.Instantiate(partSpawnerPrefab);

            Factory_SpawnPart spawner = instance.GetComponent<Factory_SpawnPart>();

            spawner.partPrefab = partPrefab;

            instance.transform.SetParent(spawnersParent);
        }
    }
}
