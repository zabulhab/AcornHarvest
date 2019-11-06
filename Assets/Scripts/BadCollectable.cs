using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCollectable : MonoBehaviour
{
    private int scoreValue;
    private ScoreTracker scoreTracker;
    private SoundPlayer soundPlayer;

    public void Awake()
    {
        // find ref on spawn
        scoreTracker = FindObjectOfType<ScoreTracker>();
        soundPlayer = FindObjectOfType<SoundPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharacterMovement>() != null)
        {
            soundPlayer.PlayExplosionSound();
            scoreTracker.AddBomb();
            Disappear();

        }
        else if (other.GetComponentInParent<CollectAllPower>() != null)
        {
            // sound played by collectallpower script
            Disappear();
        }
    }

    /// <summary>
    /// Destroys this collectable and, if needed, its parent
    /// </summary>
    [HideInInspector]
    public void Disappear()
    {
       Destroy(gameObject);
    }
}
