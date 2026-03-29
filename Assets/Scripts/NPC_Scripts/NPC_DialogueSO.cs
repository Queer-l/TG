using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/Dialogue Data")]
public class NPC_DialogueSO : ScriptableObject
{
    [TextArea(2, 4)]
    public string[] sentences; // 对话内容
    [Header("是否为最后一段话")]
    public bool isLast = false;
    [Header("时间线跳转编码")]
    public int chapter = 111;
   
}