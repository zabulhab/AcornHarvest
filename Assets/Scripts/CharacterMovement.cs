using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private readonly float DEFAULT_SPEED = 25;
    private readonly float RUN_SPEED = 45;

    private float speed;

    [SerializeField]
    private Animation jumpAnim;
    [SerializeField]
    private Animation walkLeftAnim;
    [SerializeField]
    private Animation walkRightAnim;

    // Start is called before the first frame update
    void Start()
    {
        speed = DEFAULT_SPEED;
    }

    // TODO: Sprite flip based on direction, possibly get input for direction
    // outside of FixedUpdate in order to do this
    void FixedUpdate()
    {
        // -1 for left, 1 for right
        float movementDir = Input.GetAxisRaw("Horizontal");
        if (Input.GetAxisRaw("RunHold") > 0)
        {
            speed = RUN_SPEED;
        }
        else
        {
            speed = DEFAULT_SPEED;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * movementDir, 0);
    }
}
