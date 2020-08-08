using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogText;

    public Animator animator;
    private GameObject panel;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    
    public void StartDialoug (Dialoug dialoug)
    {
        panel = dialoug.video;
        animator.SetBool("IsOpen", true);

        nameText.text = dialoug.name;

        sentences.Clear();

        foreach (string sentence in dialoug.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSenctence();
    }

    public void DisplayNextSenctence()
    {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    void EndDialogue ()
    {
        animator.SetBool("IsOpen", false);
        if (panel)
            panel.SetActive(true);
    }
}
