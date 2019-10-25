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
    private Pause pause;
    // Outside canvas prefab so can't be dropped in, must find during runtime
    private GameManager gameManager;

    private int Missed;

    [SerializeField]
    private PopupMessage popupMessageRun;

    [SerializeField]
    private PopupMessage popupMessagePause;

    [SerializeField]
    private PopupMessage popupMessagePower;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    [HideInInspector]
    public void AddPoints(int points)
    {
        score += points;
        guiController.UpdateScoreText(score);
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

    public void AddMissed()
    {
        Missed += 1;
        healthBarUI.DepleteHealth();
        if (Missed == MAXED_ALLOWED_MISSES)
        {
            finalScoreText.GetComponent<Text>().text = "x " + score;

            gameManager.GameOver();
        }
    }

}
