using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// When attached to a player, tracks the player's items caught in a row
/// </summary>
public class ComboCounter : MonoBehaviour
{
    [HideInInspector]
    public int currentComboCount { get; private set; }

    public int HighestComboOfRound { get; private set; }

    private List<int> comboCountsForRound;

    [SerializeField]
    private GameObject comboCountTextObject;


    private void Start()
    {
        currentComboCount = 0;
        HighestComboOfRound = 0;
        comboCountsForRound = new List<int>(); // reset list
        GameManager.Events.OnGameOver.AddListener(CalculateBestCombo);
    }

    [HideInInspector]
    public void IncrementComboCount()
    {
        currentComboCount++;
        if (currentComboCount == 1)
        {
            // start of new combo; make new list entry
            comboCountsForRound.Add(currentComboCount);
        }
        else if (currentComboCount > 1)// if over 0, a combo entry already exists in the list
        {
            // increment the last entry in the list (the active combo)
            Debug.Log("Count: " + comboCountsForRound.Count);
            comboCountsForRound[comboCountsForRound.Count-1]++;
        }
        InstantiateComboText();
    }

    /// <summary>
    /// Instantiates a new instance of the combo text object prefab
    /// </summary>
    private void InstantiateComboText()
    {
        Vector3 comboTextPosition = gameObject.transform.position;
        comboTextPosition.y += 2; // add vertical offset so it isn't too low
        Instantiate(comboCountTextObject, comboTextPosition, Quaternion.identity); // TODO: Change location
    }

    /// <summary>
    /// Resets the combo to 0
    /// </summary>
    public void BreakCombo()
    {
        currentComboCount = 0;
        Debug.Log("Combo broken :(");
    }

    /// <summary>
    /// Triggered on the game over event. Calculates the highest combo
    /// </summary>
    public void CalculateBestCombo()
    {
        Debug.Log("Total combo streaks: " + comboCountsForRound.Count);
        HighestComboOfRound = comboCountsForRound.Max();
        Debug.Log("BEST COMBO: " + HighestComboOfRound);
    }
}
