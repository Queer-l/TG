using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dial : MonoBehaviour
{
    [Header("对话内容")]
    public NPC_DialogueSO dialogueData;
    [Header("对话面板")]
    public GameObject dialoguePanel;
    public TMPro.TMP_Text dialogueText;

    [Header("对话人名称")]
    public string NPC_Name;
    public TMPro.TMP_Text npcNmaeText;

    [Header("时间线管理器")]
    public TimeLine_Manager timeLineManager;

    private bool isInRange;

    void Update()
    {
        if (isInRange && Input.GetButtonDown("Dialogue"))
        {
            StartDialogue();
        }
        if(isInRange && Input.GetButtonDown("ExitDialogue"))
        {
            ExitDialogue();
        }
        if (isInRange && Input.GetButtonDown("Next"))
        {
            if (dialogueData.isLast)
            {
                ExitDialogue();
                timeLineManager.ChangeTimeLine(dialogueData.chapter); 
            }
            if(!dialogueData.isLast)
            {
                TimeLineData.instance.diaCode++;
            }
        }
    }

    public void StartDialogue()
    {
        dialogueData = TimeLineData.instance.diaSoOs[TimeLineData.instance.diaCode];
        if (dialogueData == null) return;
        npcNmaeText.text = NPC_Name;
        dialoguePanel.SetActive(true);
        dialogueText.text = string.Join("\n", dialogueData.sentences);
        dialoguePanel.GetComponent<CanvasGroup>().alpha = 1;
    }
    public void ExitDialogue()
    {
        npcNmaeText.text = "";
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        dialoguePanel.GetComponent<CanvasGroup>().alpha = 0;

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
            dialoguePanel.SetActive(false);
        }
    }
}
