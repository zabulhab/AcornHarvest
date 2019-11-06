﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMessage : MonoBehaviour
{
    public int Length;
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private GameObject bg;

    /// <summary>
    /// If this message is the last, it should tell the game manager when it finishes
    /// displaying so we know that the user has seen all of the messages once.
    /// </summary>
    public bool IsLastMessage;


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
        text.gameObject.SetActive(false);
        bg.gameObject.SetActive(false);
        if (IsLastMessage)
        {
            Debug.Log("SET TRUE");
            GameManager.Instance.popupMessagesAlreadyShown = true;
        }
    }

    /// <summary>
    /// Keeps the message showing, ignoring timescale from pausing
    /// </summary>
    /// <returns>The image.</returns>
    private IEnumerator KeepPopupShowing()
    {
        yield return new WaitForSecondsRealtime(Length);
        HideMessage();
    }


}
