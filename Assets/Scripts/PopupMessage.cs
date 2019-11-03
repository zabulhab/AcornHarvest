using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMessage : MonoBehaviour
{
    public int Length;
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private GameObject bg;

    private bool showing = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Length == 0) // set if not set
        {
            Length = 2;
        }
    }

    public void ShowMessage()
    {
        showing = true;
        text.gameObject.SetActive(true);
        bg.gameObject.SetActive(true);

        // fades the image out when you click
        StartCoroutine(KeepPopupShowing());
    }

    /// <summary>
    /// Hides the message. Called by the waiting coroutine KeepPopupShowing or
    /// the game over method, which should also make the message disappear 
    /// </summary>
    [HideInInspector]
    public void HideMessage()
    {
        showing = false;
        text.gameObject.SetActive(false);
        bg.gameObject.SetActive(false);
    }

    /// <summary>
    /// Keeps the message showing, ignoring timescale from pausing
    /// </summary>
    /// <returns>The image.</returns>
    private IEnumerator KeepPopupShowing()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(Length);
        print(Time.time);
        HideMessage();
    }


}
