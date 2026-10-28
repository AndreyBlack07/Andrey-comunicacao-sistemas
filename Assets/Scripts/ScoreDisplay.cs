using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private ScoreSystem scoreSystem;

    private Label scoreLabel;
    private Coroutine initializationRoutine;

    private void OnEnable()
    {
        if (scoreSystem == null)
        {
            Debug.LogError("Atribui o ScoreSystem ao ScoreDisplay no Inspector.", this);
            enabled = false;
            return;
        }

        initializationRoutine = StartCoroutine(InitializeWhenReady());
    }

    private IEnumerator InitializeWhenReady()
    {
        yield return null;

        UIDocument uiDocument = GetComponent<UIDocument>();
        scoreLabel = uiDocument.rootVisualElement.Q<Label>("score-label");
        if (scoreLabel == null)
        {
            Debug.LogError("Confirma que existe um Label chamado 'score-label' no UXML.", this);
            initializationRoutine = null;
            enabled = false;
            yield break;
        }

        scoreSystem.ScoreChanged += UpdateDisplay;
        UpdateDisplay(scoreSystem.CurrentScore);
        initializationRoutine = null;
    }

    private void OnDisable()
    {
        if (initializationRoutine != null)
        {
            StopCoroutine(initializationRoutine);
            initializationRoutine = null;
        }

        if (scoreSystem != null)
        {
            scoreSystem.ScoreChanged -= UpdateDisplay;
        }
    }

    private void UpdateDisplay(int value)
    {
        if (scoreLabel != null)
        {
            scoreLabel.text = $"Pontuação: {value}";
        }
    }
}
