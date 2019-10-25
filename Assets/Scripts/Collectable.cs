using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
	private int scoreValue;
    private ScoreTracker scoreTracker;
    private GameManager gameManager;
    private SoundPlayer soundPlayer;

    public void Awake()
    {
        // find ref on spawn
        gameManager = FindObjectOfType<GameManager>();
        scoreTracker = FindObjectOfType<ScoreTracker>();
        soundPlayer = FindObjectOfType<SoundPlayer>();
        gameManager.IncrementTotalSpawned();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharacterMovement>() != null)
        {
            Debug.Log("GOT A POINT");
			scoreTracker.AddPoints(1);
            soundPlayer.PlayRandomCollectSound();
            Disappear();
        }
        else if (other.GetComponentInParent<CollectAllPower>() != null)
        {
            Debug.Log("Collected By Power");
            scoreTracker.AddPoints(1);
            // sound played by collectallpower script
            Disappear();
        }
        Debug.Log(other);
    }

    /// <summary>
    /// Destroys this collectable and, if needed, its parent
    /// </summary>
    [HideInInspector]
    public void Disappear()
    {
        Debug.Log(gameObject.transform.parent.name);
        // if this is the last collectable, destroy whole set prefab
        if (gameObject.transform.parent.childCount == 1) 
        {
            Debug.Log("should destroy parent");
            Destroy(gameObject.transform.parent.gameObject);
        }
        else // destroy just this collectable
        {
            Destroy(gameObject);
        }
    }
}
