using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    private readonly int MAXED_ALLOWED_MISSES = 10;
    public int score { get; set; }
    [SerializeField]
    private GUIController guiController;
    [SerializeField]
    private HealthBarUI healthBarUI;
    [SerializeField]
    private GameObject finalScoreText;
    [SerializeField]
    private GameObject finalMissText;
    [SerializeField]
    private GameObject finalComboText;
    [SerializeField]
    private Pause pause;

    [SerializeField]
    private ComboCounter comboCounter;

    private int Missed;

    [SerializeField]
    private PopupMessage popupMessageRun;

    [SerializeField]
    private PopupMessage popupMessagePause;

    [SerializeField]
    private PopupMessage popupMessagePower;

    [HideInInspector]
    public void AddPoints(int points)
    {
        score += points;
        guiController.UpdateScoreText(score);
        comboCounter.IncrementComboCount();
        if (GameManager.Instance.popupMessagesAlreadyShown)
        {
            return;
        }
        if (score == 10)
        {
            popupMessageRun.ShowMessage();
        }
        if (score == 40)
        {
            popupMessagePause.ShowMessage();
        }
        if (score == 80)
        {
            popupMessagePower.ShowMessage();
        }
    }

    /// <summary>
    /// Called when the player fails to catch an acorn
    /// </summary>
    public void AddMissed()
    {
        Missed += 1;
        healthBarUI.DepleteHealth();
        comboCounter.BreakCombo();
        if (Missed == MAXED_ALLOWED_MISSES)
        {
            GameManager.Instance.GameOver();
            finalScoreText.GetComponent<Text>().text = "x " + score;
            finalMissText.GetComponent<Text>().text = "x " + Missed;
            finalComboText.GetComponent<Text>().text = "x " + comboCounter.HighestComboOfRound;
        }
    }

    /// <summary>
    /// Called when the player catches a bomb
    /// Right now, it counts as two misses, takes 5 collected acorns from your total,
    /// and breaks your combo streak
    /// </summary>
    public void AddBomb()
    {
        AddMissed();
        AddMissed();
        guiController.UpdateScoreText(score);
        if (score < 5)
        {
            score = 0;
        }
        else
        {
            score -= 5;
        }
        // explode some collected acorns??
    }

}
