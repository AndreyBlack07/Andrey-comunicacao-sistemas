using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PDJ/Dialogue Node", fileName = "DialogueNode")]
public class DialogueNode : ScriptableObject
{
    [SerializeField] private string speaker;
    [SerializeField, TextArea(2, 5)] private string dialogueText;
    [SerializeField] private List<DialogueChoice> choices = new List<DialogueChoice>();

    public string Speaker => speaker;
    public string DialogueText => dialogueText;
    public IReadOnlyList<DialogueChoice> Choices => choices;
}
