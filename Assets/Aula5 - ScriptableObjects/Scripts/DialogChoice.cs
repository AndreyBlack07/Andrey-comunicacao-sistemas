using System;
using UnityEngine;

[Serializable]
public class DialogueChoice
{
    [SerializeField] private string label;
    [SerializeField] private DialogueNode nextNode;

    public string Label => label;
    public DialogueNode NextNode => nextNode;
}
