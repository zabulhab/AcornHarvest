using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to spawn children collectables
// Attached to the spawn point gameobject
public class SpawnObjects : MonoBehaviour
{
    private Vector3 spawnPoint;

    [SerializeField]
    private List<GameObject> LTRList = new List<GameObject>();
    [SerializeField]
    private List<GameObject> RTLList = new List<GameObject>();
    [SerializeField]
    private List<GameObject> MList = new List<GameObject>();

    private List<List<GameObject>> listOfPrefabLists = new List<List<GameObject>>();

    [HideInInspector]
    public GameObject curLastAcorn; // set by the last acorn when it spawns


    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector3(gameObject.transform.position.x, 
                                 gameObject.transform.position.y + 10f, 
                                 0f);

        // add all lists to list list
        listOfPrefabLists.Add(LTRList);
        listOfPrefabLists.Add(RTLList);
        listOfPrefabLists.Add(MList);

        // choose random prefab and spawn it
        Spawn(ChooseRandSpawnPrefab());
    }

    private GameObject ChooseRandSpawnPrefab()
    {
        // choose list
        List<GameObject> chosenList = listOfPrefabLists[Random.Range(0, 2)];

        // choose prefab
        return chosenList[Random.Range(0, chosenList.Count)];
    }

    private void Spawn(GameObject prefab)
    {
        Instantiate(prefab, spawnPoint, Quaternion.identity);
    }

    // called by last acorn when it exits spawn point
    public void SpawnNewObjects()
    {
        Spawn(ChooseRandSpawnPrefab());
    }
}
