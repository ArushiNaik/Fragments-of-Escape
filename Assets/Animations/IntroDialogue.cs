using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    [Header("Typing Settings")]
    public float typingSpeed = 0.04f;
    public float lineDelay = 2f;

    private string[] lines = new string[]
    {
        "FRIEND: Hello? ...Please tell me you can hear me.",
        "FRIEND: I'm stuck. I'm trapped inside this house.",
        "FRIEND: I called the police... but no one is willing to risk their lives.",
        "FRIEND: They said it's already taken too many.",
        "PLAYER: WHAT DO YOU MEAN IT'S TAKEN SO MANY??",
        "FRIEND: Please... I don't know how much longer I can stay here.",
        "",
        "PLAYER: Calm down. Tell me where you are.",
        "FRIEND: Top floor... I locked myself inside one of the rooms.",
        "PLAYER: Don't worry. I'm coming to get you.",
        "FRIEND: PLEASE BE CAREFUL",
        "",
        "ITS WATCHING YOU",
        "",
        "***You arrive at the house.***",
        "***It stands silent. Watching.***",
        "***The door shuts behind you.***",
        "",
        "FRIEND: The main door key... it's up here with me.",
        "FRIEND: You need the fragments.",
        "FRIEND: The pieces of a broken picture scattered around the house.",
        "",
        "Find the picture fragments.",
        "Reach the top floor.",
        "",
        "Save her."
    };

    void Start()
    {
        StartCoroutine(PlayDialogue());
    }

    IEnumerator PlayDialogue()
    {
        foreach (string line in lines)
        {
            yield return StartCoroutine(TypeLine(line));
            yield return new WaitForSeconds(lineDelay);
        }

        SceneManager.LoadScene("Game");
    }

    IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";

        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;

            // Slight pause for punctuation
            if (letter == '.' || letter == ',' || letter == '!' || letter == '?')
                yield return new WaitForSeconds(typingSpeed * 6f);
            else
                yield return new WaitForSeconds(typingSpeed);
        }
    }
}