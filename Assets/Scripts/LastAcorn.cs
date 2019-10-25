using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This should be attached to the last acorn
// It tells the spawner when it has appeared 
// to update the current last acorn, and 
public class LastAcorn : MonoBehaviour
{
    private SpawnObjects spawnObjects;

    // Start is called before the first frame update
    void Start()
    {
        spawnObjects = FindObjectOfType<SpawnObjects>();
        spawnObjects.curLastAcorn = this.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // if spawn point entered by this last acorn
        if (other.tag == "SpawnPoint")
        {
            Debug.Log("last acorn passed spawn point");
            other.GetComponent<SpawnObjects>().SpawnNewObjects();
        }
    }
}
