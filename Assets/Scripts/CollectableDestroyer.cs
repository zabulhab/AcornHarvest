using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroys uncollected collectables
public class CollectableDestroyer : MonoBehaviour
{
    [SerializeField]
    private ScoreTracker scoreTracker;
    [SerializeField]
    private SoundPlayer soundPlayer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        scoreTracker.AddMissed();
        other.GetComponent<Collectable>().Disappear();
        Debug.Log("destroyed something");
        soundPlayer.PlayMissSound();
    }
}
