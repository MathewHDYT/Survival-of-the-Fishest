using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    private void OnTriggerEnter2D()
    {
        if (gm.gotrod)
            return;

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerExit2D()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }
}
