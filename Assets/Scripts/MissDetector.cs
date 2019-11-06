using UnityEngine;

// Attached to a child object collider of the player meant to detect misses
// and display the miss text if needed
public class MissDetector : MonoBehaviour
{
    [SerializeField]
    private ScoreTracker scoreTracker;
    [SerializeField]
    private SoundPlayer soundPlayer;
    [SerializeField]
    private GameObject MissText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if it's a collectable, we miss it
        if (other.GetComponent<Collectable>() != null)
        {
            scoreTracker.AddMissed();
            soundPlayer.PlayMissSound();
            BoxCollider2D playerCollider = transform.root.GetComponent<BoxCollider2D>();

            // Get the closest point on the player collider to the 
            // collectable's position and show miss text there
            Vector3 missTextPosition = playerCollider.ClosestPoint(other.GetComponent<Transform>().position);
            missTextPosition.y += 3; // add vertical offset so it isn't too low
            Instantiate(MissText, missTextPosition, Quaternion.identity);
        }
    }
}
