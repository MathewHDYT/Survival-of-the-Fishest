using UnityEngine;

public class DialogueStart : MonoBehaviour
{
    public Dialogue dialogue;
    private bool playeddialogue;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    private void OnTriggerEnter2D()
    {
        if (gm.playeddialogue || gm.currentscore < 50 || !gm.gotrod)
            return;

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        gm.playeddialogue = true;
    }

    private void OnTriggerExit2D()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }
}
