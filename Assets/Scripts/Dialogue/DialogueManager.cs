using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject FishingRod;
    public Transform NPCposition;

    public Animator animator;

    // First In First Out Collection
    private Queue<string> sentences;

    GameManager gm;


    // Use this for initialization
    void Start()
    {
        gm = GameManager.instance;
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            FindObjectOfType<AudioManager>().Play("Talk");
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);

        if (gm.playeddialogue)
        {
            gm.DecreaseScore(50);
            gm.GameWon();
        }

        if (gm.gotrod)
            return;

        Instantiate(FishingRod, NPCposition.transform.position, Quaternion.identity);
        gm.gotrod = true;
    }
}