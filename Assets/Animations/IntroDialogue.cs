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

    [Header("Typing Sound")]
    public AudioSource typingAudioSource;
    public AudioClip typingClip;
    public float soundInterval = 0.12f;
    public bool ignoreSpaces = true;

    [Header("Special Sound Effects")]
    public AudioSource sfxAudioSource;
    public AudioClip doorCloseClip;

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
        "IT'S WATCHING YOU",
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

    IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";

        bool playTypingSound =
            line == "FRIEND: Hello? ...Please tell me you can hear me." ||
            line == "FRIEND: I'm stuck. I'm trapped inside this house." ||
            line == "FRIEND: I called the police... but no one is willing to risk their lives." ||
            line == "FRIEND: They said it's already taken too many." ||
            line == "PLAYER: WHAT DO YOU MEAN IT'S TAKEN SO MANY??" ||
            line == "FRIEND: Please... I don't know how much longer I can stay here." ||
            line == "PLAYER: Calm down. Tell me where you are." ||
            line == "FRIEND: Top floor... I locked myself inside one of the rooms." ||
            line == "PLAYER: Don't worry. I'm coming to get you." ||
            line == "FRIEND: PLEASE BE CAREFUL" ||
            line == "FRIEND: The main door key... it's up here with me." ||
            line == "FRIEND: You need the fragments." ||
            line == "FRIEND: The pieces of a broken picture scattered around the house.";

        bool firstSoundPlayed = false;
        float soundTimer = 0f;

        foreach (char letter in line)
        {
            dialogueText.text += letter;

            if (playTypingSound &&
                typingAudioSource != null &&
                typingClip != null &&
                (!ignoreSpaces || !char.IsWhiteSpace(letter)))
            {
                if (!firstSoundPlayed)
                {
                    typingAudioSource.pitch = Random.Range(0.95f, 1.05f);
                    typingAudioSource.PlayOneShot(typingClip);
                    firstSoundPlayed = true;
                    soundTimer = 0f;
                }
                else
                {
                    soundTimer += Time.deltaTime;

                    if (soundTimer >= soundInterval)
                    {
                        typingAudioSource.pitch = Random.Range(0.95f, 1.05f);
                        typingAudioSource.PlayOneShot(typingClip);
                        soundTimer = 0f;
                    }
                }
            }
            if (letter == '.' || letter == ',' || letter == '!' || letter == '?')
                yield return new WaitForSeconds(typingSpeed * 6f);
            else
                yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator PlayDialogue()
    {
        foreach (string line in lines)
        {
            if (line == "***The door shuts behind you.***")
            {
                if (sfxAudioSource != null && doorCloseClip != null)
                    sfxAudioSource.PlayOneShot(doorCloseClip);
            }

            yield return StartCoroutine(TypeLine(line));
            yield return new WaitForSeconds(lineDelay);
        }

        SceneManager.LoadScene("Game");
    }
   
}


//IEnumerator TypeLine(string line)
//{
//    dialogueText.text = "";

//    bool playTypingSound =
//        !string.IsNullOrWhiteSpace(line) &&
//        !line.Contains("***");

//    bool firstSoundPlayed = false;
//    float soundTimer = 0f;

//    foreach (char letter in line)
//    {
//        dialogueText.text += letter;

//        bool isValidChar =
//            char.IsLetterOrDigit(letter) ||
//            (!ignoreSpaces && char.IsWhiteSpace(letter));

//        if (playTypingSound &&
//            typingAudioSource != null &&
//            typingClip != null &&
//            isValidChar)
//        {
//            if (!firstSoundPlayed)
//            {
//                typingAudioSource.clip = typingClip;
//                typingAudioSource.time = 0f;
//                typingAudioSource.pitch = Random.Range(0.95f, 1.05f);
//                typingAudioSource.Play();

//                firstSoundPlayed = true;
//                soundTimer = 0f;
//            }
//            else
//            {
//                soundTimer += Time.deltaTime;

//                if (soundTimer >= soundInterval)
//                {
//                    typingAudioSource.Stop();
//                    typingAudioSource.clip = typingClip;
//                    typingAudioSource.time = 0f;
//                    typingAudioSource.pitch = Random.Range(0.95f, 1.05f);
//                    typingAudioSource.Play();

//                    soundTimer = 0f;
//                }
//            }
//        }

//        if (letter == '.' || letter == ',' || letter == '!' || letter == '?')
//            yield return new WaitForSeconds(typingSpeed * 6f);
//        else
//            yield return new WaitForSeconds(typingSpeed);
//    }
//}