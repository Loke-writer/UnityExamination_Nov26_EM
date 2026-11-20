using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI textBox;
    [SerializeField] private Button nextButton;
    [SerializeField] List<string> dialogue;

    [SerializeField] private UnityEvent onStartDialogue;
    [SerializeField] private UnityEvent onEndDialogue;
    [SerializeField] private List<string> comletedDialogue = new List<string>();
    [SerializeField] private bool challengeCompleted;
    
    private List<string> currentDialogue;
    private int currentIndex = -1;


    private void Update()
    {
        if (currentIndex >= 0 &&
            Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            NextDialogue();
        }
    }

    public void Completechallenge()
    {
        challengeCompleted = true;
    }
    public void NextDialogue()
    {
        // If dialogue wasn't started: run the onStartDialogue-event, and add this dialogue to the Next-Button
        if (currentIndex < 0)
        {
            currentDialogue = challengeCompleted ? comletedDialogue : dialogue;
            
            onStartDialogue?.Invoke();
            nextButton?.onClick.AddListener(NextDialogue);
        }
        
        // Move to the next item in the list of dialogue-lines
        currentIndex++;
        // If we're not at the end of the list yet: update text in text-box
        if (currentIndex < currentDialogue.Count)
        {
            textBox.text = currentDialogue[currentIndex];
        }
        // If we are at the end of the list: run the onEndDialogue-event, reset the index (so that the dialogue can be restarted) and remove this dialog from the next-button
        else
        {
            textBox.text = "";
            onEndDialogue?.Invoke();
            currentIndex = -1;
            nextButton?.onClick.RemoveListener(NextDialogue);
        }
    }
}