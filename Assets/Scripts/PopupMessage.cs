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

    private float startTime = 0f;
    private bool showing = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Length == 0) // set if not set
        {
            Length = 2;
        }
    }

    private void Update()
    {
        if (showing && Time.time - startTime > Length)
        {
            HideMessage();
        }
    }

    public void ShowMessage()
    {
        showing = true;
        text.gameObject.SetActive(true);
        bg.gameObject.SetActive(true);
        startTime = Time.time;
    }

    public void HideMessage()
    {
        showing = false;
        text.gameObject.SetActive(false);
        bg.gameObject.SetActive(false);
    }


}
