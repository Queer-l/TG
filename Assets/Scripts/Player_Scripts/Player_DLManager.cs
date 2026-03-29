using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player_DLManager : MonoBehaviour
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
    
    public void StartDialogue()
    {
        Time.timeScale = 0;
        dialogueData = TimeLineData.instance.diaSoOs[TimeLineData.instance.diaCode];
        if (dialogueData == null) return;

        npcNmaeText.text = NPC_Name;
        dialoguePanel.SetActive(true);
        dialogueText.text = string.Join("\n", dialogueData.sentences);
        dialoguePanel.GetComponent<CanvasGroup>().alpha = 1;
    }
    public void ExitDialogue()
    {
        Time.timeScale = 1;
        npcNmaeText.text = "";
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        dialoguePanel.GetComponent<CanvasGroup>().alpha = 0;

    }

    public void Update()
    {
        
        if (TimeLineData.instance.playerIsOnDL)
        {
            StartDialogue();
            if (Input.GetButtonDown("Next"))
            {
                UnityEngine.Debug.Log($"章节：{dialogueData.chapter}");
                if (dialogueData.isLast)
                {
                    ExitDialogue();
                    UnityEngine.Debug.Log($"章节：{dialogueData.chapter}");
                    timeLineManager.ChangeTimeLine(dialogueData.chapter);
                }
                if (!dialogueData.isLast)
                {
                    TimeLineData.instance.diaCode++;
                }
            }
        }
        
    }
}
