using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dial : MonoBehaviour
{
    [Header("∂‘ª∞…Ë÷√")]
    public bool isonline = false;

    private bool isInRange;

    void Update()
    {
        
        if (isInRange && Input.GetButtonDown("Dialogue"))
            {
            TimeLineData.instance.playerIsOnDL = true;
            }
            if (isInRange && Input.GetButtonDown("ExitDialogue"))
            {
            TimeLineData.instance.playerIsOnDL = false;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
