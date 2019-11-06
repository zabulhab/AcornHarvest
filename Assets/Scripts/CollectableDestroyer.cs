using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroys uncollected collectables
public class CollectableDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collectable>() != null)
        {
            other.GetComponent<Collectable>().Disappear();
        }
        else if (other.GetComponent<BadCollectable>() != null)
        {
            other.GetComponent<BadCollectable>().Disappear();
        }
        Debug.Log("destroyed something");
    }
}
