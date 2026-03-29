using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Open : MonoBehaviour
{
    public CanvasGroup canva;
    private bool isOpened;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("OpenBag")&& isOpened)
        {
            canva.alpha = 0;
            isOpened = false;
        }
        else if(Input.GetButtonDown("OpenBag") && isOpened == false)
        {
            canva.alpha = 1;
            isOpened = true;
        }
    }
}
