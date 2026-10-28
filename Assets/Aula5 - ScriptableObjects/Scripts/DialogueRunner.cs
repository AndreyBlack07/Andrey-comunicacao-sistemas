using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class DialogueRunner : MonoBehaviour
{
    [Header("Dialogue data")]
    [SerializeField] private DialogueNode startNode;

    private Label speakerLabel;
    private Label dialogueLabel;
    private VisualElement choicesRoot;
    private readonly Dictionary<Button, System.Action> activeButtons =
        new Dictionary<Button, System.Action>();
    private Coroutine initializationRoutine;
    private DialogueNode currentNode;

    private void OnEnable()
    {
        if (startNode == null)
        {
            Debug.LogError("Atribui o nó inicial ao DialogueRunner.", this);
            enabled = false;
            return;
        }

        initializationRoutine = StartCoroutine(InitializeWhenReady());
    }

    private IEnumerator InitializeWhenReady()
    {
        yield return null;

        UIDocument uiDocument = GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;
        speakerLabel = root.Q<Label>("speaker-label");
        dialogueLabel = root.Q<Label>("dialogue-label");
        choicesRoot = root.Q<VisualElement>("choices-root");

        if (speakerLabel == null || dialogueLabel == null || choicesRoot == null)
        {
            Debug.LogError(
                "Confirma que o UXML contém 'speaker-label', 'dialogue-label' e 'choices-root'.",
                this);
            initializationRoutine = null;
            enabled = false;
            yield break;
        }

        initializationRoutine = null;
        ShowNode(startNode);
    }

    private void OnDisable()
    {
        if (initializationRoutine != null)
        {
            StopCoroutine(initializationRoutine);
            initializationRoutine = null;
        }

        ClearChoices();
        currentNode = null;
    }

    private void ShowNode(DialogueNode node)
    {
        if (node == null)
        {
            Debug.LogError("O nó de diálogo seguinte não está atribuído.", this);
            ShowConfigurationError();
            return;
        }

        if (!ValidateChoices(node))
        {
            ShowConfigurationError();
            return;
        }

        currentNode = node;
        speakerLabel.text = currentNode.Speaker;
        dialogueLabel.text = currentNode.DialogueText;
        ClearChoices();

        if (currentNode.Choices.Count == 0)
        {
            CreateChoiceButton("Terminar conversa", EndConversation);
            return;
        }

        foreach (DialogueChoice choice in currentNode.Choices)
        {
            DialogueNode nextNode = choice.NextNode;
            CreateChoiceButton(choice.Label, () => ShowNode(nextNode));
        }
    }

    private bool ValidateChoices(DialogueNode node)
    {
        if (node.Choices == null)
        {
            Debug.LogError($"O nó '{node.name}' não tem uma lista de opções.", node);
            return false;
        }

        foreach (DialogueChoice choice in node.Choices)
        {
            if (choice == null || string.IsNullOrWhiteSpace(choice.Label) || choice.NextNode == null)
            {
                Debug.LogError(
                    $"O nó '{node.name}' tem uma opção sem texto ou sem nó seguinte.",
                    node);
                return false;
            }
        }

        return true;
    }

    private void CreateChoiceButton(string label, System.Action action)
    {
        Button button = new Button
        {
            text = label,
            name = "dialogue-choice"
        };
        button.clicked += action;
        button.AddToClassList("dialogue-choice");
        choicesRoot.Add(button);
        activeButtons.Add(button, action);
    }

    private void ClearChoices()
    {
        foreach (KeyValuePair<Button, System.Action> choiceButton in activeButtons)
        {
            choiceButton.Key.clicked -= choiceButton.Value;
            choiceButton.Key.RemoveFromHierarchy();
        }

        activeButtons.Clear();
    }

    private void EndConversation()
    {
        ClearChoices();
        currentNode = null;
        speakerLabel.text = string.Empty;
        dialogueLabel.text = "A conversa terminou.";
    }

    private void ShowConfigurationError()
    {
        ClearChoices();
        currentNode = null;
        speakerLabel.text = string.Empty;
        dialogueLabel.text = "Erro na configuração do diálogo. Consulta a Console.";
    }
}
