using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    private float fallSpeed;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        // check the GameManager for the current fall speed
        fallSpeed = GameManager.Instance.CurrentFallSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, fallSpeed);
    }
}
