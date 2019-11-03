using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach this to a game object with a child screen-wide collider
/// When collectables collide with it, they will know to be collected
/// </summary>
public class CollectAllPower : MonoBehaviour
{
    private bool currentlyConsuming = false;
    private int charge;
    [SerializeField]
    private GUIController guiController;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private SoundPlayer soundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChargeBar", 5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && !gameManager.paused && !currentlyConsuming && charge == 100)
        {
            ConsumeAllOnScreen();
        }
        else if (currentlyConsuming)
        {
            currentlyConsuming = false;
            transform.GetChild(0).gameObject.SetActive(false);
            guiController.HideFullChargeText();
            guiController.DepleteChargeUI();
        }
        if (charge == 100)
        {
            guiController.ShowFullChargeText();
        }
    }

    private void ConsumeAllOnScreen()
    {
        currentlyConsuming = true;
        transform.GetChild(0).gameObject.SetActive(true);
        charge = 0;
        soundPlayer.PlayPowerSound();
    }

    private void ChargeBar()
    {
        if (charge < 100)
        {
            charge += 10;
            guiController.IncrementChargeUI();
        }
    }
}
