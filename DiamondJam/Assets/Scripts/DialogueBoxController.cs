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


    public void SingleDialogue(string text, float duration)
    {
        boxBackground.gameObject.SetActive(true);
        displayedText.text = "";

        if (text.Length * timeBetweenCaracter > duration)
            duration = text.Length * timeBetweenCaracter;
        StartCoroutine(TextApparition(text, duration));
    }


    private IEnumerator TextApparition(string text, float duration)
    {
        float time = 0;
        int index = 0;
        while (time <= duration)
        {
            if(index < text.Length)
                displayedText.text += text[index];
            index++;
            time += timeBetweenCaracter;
            yield return new WaitForSeconds(timeBetweenCaracter);
        }

        boxBackground.gameObject.SetActive(false);
    }
}
