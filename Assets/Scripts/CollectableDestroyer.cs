using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroys uncollected collectables
public class CollectableDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Collectable>().Disappear();
        Debug.Log("destroyed something");
    }
}
