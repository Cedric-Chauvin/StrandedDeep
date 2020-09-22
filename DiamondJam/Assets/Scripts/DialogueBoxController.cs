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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
                displayedText.text = textToDisplay;
            }
            else if (boxBackground.gameObject.activeSelf == true)
                boxBackground.gameObject.SetActive(false);
        }
    }


    public void SingleDialogue(string text)
    {
        boxBackground.gameObject.SetActive(true);
        displayedText.text = "";
        textToDisplay = text;

        coroutine = StartCoroutine(TextApparition(text));
    }


    private IEnumerator TextApparition(string text)
    {
        int index = 0;
        while (displayedText.text.Length < text.Length)
        {
            if(index < text.Length)
                displayedText.text += text[index];
            index++;
            yield return new WaitForSeconds(timeBetweenCaracter);
        }

        coroutine = null;
    }
}
