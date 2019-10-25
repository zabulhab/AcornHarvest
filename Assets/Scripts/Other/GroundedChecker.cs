using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedChecker : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Ground>() != null)
        {
            Debug.Log("GROUNDED");
            GetComponentInParent<CharacterMovement>().grounded = true;
            Debug.Log("TEST");
        }
    }
}
