using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private ScoreDoor scoreDoor;

    private VisualElement victoryPanel;
    private Coroutine initializationRoutine;

    private void OnEnable()
    {
        if (scoreDoor == null)
        {
            Debug.LogError("Atribui a ScoreDoor ao VictoryScreen.", this);
            enabled = false;
            return;
        }

        initializationRoutine = StartCoroutine(InitializeWhenReady());
    }

    private IEnumerator InitializeWhenReady()
    {
        yield return null;

        UIDocument uiDocument = GetComponent<UIDocument>();
        victoryPanel = uiDocument.rootVisualElement.Q<VisualElement>("victory-panel");
        if (victoryPanel == null)
        {
            Debug.LogError("Confirma que existe um VisualElement chamado 'victory-panel' no UXML.", this);
            initializationRoutine = null;
            enabled = false;
            yield break;
        }

        victoryPanel.style.display = DisplayStyle.None;
        scoreDoor.OnDoorEntered += ShowVictory;
        initializationRoutine = null;
    }

    private void OnDisable()
    {
        if (initializationRoutine != null)
        {
            StopCoroutine(initializationRoutine);
            initializationRoutine = null;
        }

        if (scoreDoor != null)
        {
            scoreDoor.OnDoorEntered -= ShowVictory;
        }
    }

    private void ShowVictory()
    {
        if (victoryPanel != null)
        {
            victoryPanel.style.display = DisplayStyle.Flex;
        }
    }
}
