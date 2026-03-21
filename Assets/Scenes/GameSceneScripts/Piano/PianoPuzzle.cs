using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PianoPuzzle : MonoBehaviour
{
    public Image keyC;
    public Image keyDSharp;
    public Image keyG;

    public Color correctColor = Color.green;

    public GameObject pianoPanel;

    public AudioSource audioSource;
    public AudioClip noteC;
    public AudioClip noteDSharp;
    public AudioClip noteG;

    public GameObject rewardKey;

    private string[] correct = { "C", "D#", "G" };

    private string[] playerInput = new string[3];
    private Image[] pressedKeys = new Image[3];

    private int inputIndex = 0;
    private bool isChecking = false;

    public void PressKey(string note)
    {
        if (isChecking) return;

        PlaySound(note);

        if (inputIndex >= playerInput.Length)
            return;

        playerInput[inputIndex] = note;
        pressedKeys[inputIndex] = GetKeyImage(note);

        inputIndex++;

        if (inputIndex == playerInput.Length)
        {
            StartCoroutine(CheckSequence());
        }
    }

    Image GetKeyImage(string note)
    {
        switch (note)
        {
            case "C": return keyC;
            case "D#": return keyDSharp;
            case "G": return keyG;
            default:
                Debug.LogWarning("Unknown note: " + note);
                return null;
        }
    }

    void PlaySound(string note)
    {
        if (audioSource == null) return;

        if (note == "C") audioSource.PlayOneShot(noteC);
        if (note == "D#") audioSource.PlayOneShot(noteDSharp);
        if (note == "G") audioSource.PlayOneShot(noteG);
    }

    IEnumerator CheckSequence()
    {
        isChecking = true;

        bool isCorrect = true;

        for (int i = 0; i < correct.Length; i++)
        {
            if (playerInput[i] != correct[i])
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            for (int i = 0; i < pressedKeys.Length; i++)
            {
                if (pressedKeys[i] != null)
                    StartCoroutine(SetColorNextFrame(pressedKeys[i], correctColor));
            }

            if (GameMessageManager.instance != null)
                GameMessageManager.instance.ShowMessage("Yay! Puzzle Solved!");

            if (rewardKey != null)
                rewardKey.SetActive(true);

            yield return new WaitForSeconds(2f);

            ExitPiano();
        }
        else
        {
            if (GameMessageManager.instance != null)
                GameMessageManager.instance.ShowMessage("Wrong combination!");

            yield return new WaitForSeconds(2f);

            ResetSequence();
        }

        isChecking = false;
    }

    void ExitPiano()
    {
        if (pianoPanel != null)
            pianoPanel.SetActive(false);

        if (EventSystem.current != null)
            EventSystem.current.SetSelectedGameObject(null);

        if (InteractionPromptUI.instance != null)
            InteractionPromptUI.instance.HidePrompt();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Collider2D col = player.GetComponent<Collider2D>();
            if (col != null)
            {
                col.enabled = false;
                col.enabled = true;
            }
        }
    }

    void SetKeyColor(Color color)
    {
        if (keyC != null) keyC.color = color;
        if (keyDSharp != null) keyDSharp.color = color;
        if (keyG != null) keyG.color = color;
    }

    public void ResetSequence()
    {
        inputIndex = 0;

        for (int i = 0; i < playerInput.Length; i++)
        {
            playerInput[i] = "";
            pressedKeys[i] = null;
        }

        // Keep correct base colors
        //if (keyC != null) keyC.color = Color.white;
        //if (keyDSharp != null) keyDSharp.color = Color.black;
        //if (keyG != null) keyG.color = Color.white;
    }

    void OnEnable()
    {
        ResetSequence();
    }

    IEnumerator SetColorNextFrame(Image img, Color color)
    {
        yield return null;
        if (img != null)
            img.color = color;
    }
}