using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxController : MonoBehaviour
{

    #region Singleton
    private static DialogueBoxController instance;

    public static DialogueBoxController Instance { get => instance; }
    #endregion

    [SerializeField]
    private RectTransform boxBackground;
    [SerializeField]
    private Text displayedText;
    [SerializeField]
    private float timeBetweenCaracter;

    private Coroutine coroutine;
    private string textToDisplay;
    private bool canPasse;
    private bool apparitionSkip;
    public AudioSource currentAudio;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
            instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPasse)
        {
            if (coroutine != null)
            {
                displayedText.text = textToDisplay;
                apparitionSkip = true;
            }
            else if (boxBackground.gameObject.activeSelf == true)
                KillBox();
        }
    }

    public void KillBox()
    {
        boxBackground.gameObject.SetActive(false);
        if(currentAudio!=null)
            currentAudio.Stop();
        if(coroutine != null)
            StopCoroutine(coroutine);
        coroutine = null;
        currentAudio = null;
    }


    public void SingleDialogue(string text, float extraTime)
    {
        boxBackground.gameObject.SetActive(true);
        displayedText.text = "";
        textToDisplay = text;
        if (coroutine != null)
            StopCoroutine(coroutine);

        canPasse = false;
        apparitionSkip = false;
        coroutine = StartCoroutine(TextApparition(text, extraTime));
    }


    private IEnumerator TextApparition(string text, float extraTime)
    {
        int index = 0;
        while (displayedText.text.Length < text.Length && !apparitionSkip)
        {
            if(index < text.Length)
                displayedText.text += text[index];
            index++;
            yield return new WaitForSeconds(timeBetweenCaracter);
            canPasse = true;
        }
        float time = 0;
        while (time < extraTime)
        {
            yield return new WaitForSeconds(0.1f);
            time += 0.1f;
        }

        coroutine = null;
        KillBox();
    }
}
