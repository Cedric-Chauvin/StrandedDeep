using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton

    private static UIManager instance;

    public static UIManager Instance { get => instance; }
    #endregion

    [SerializeField]
    private Image interactionFill;
    public Image InteractionFill { get => interactionFill; private set => interactionFill = value; }

    public Image interactionImage;

    [SerializeField]
    private Image fade;
    [SerializeField]
    private float fadeDuration;

    public bool fadeIsActive;
    public AudioMixer master;
    private Coroutine fadeRoutine;
    private float masterVolume;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
            instance = this;
        master.GetFloat("Master", out masterVolume);
    }

    private void Start()
    {
        if(fadeIsActive)
            master.SetFloat("Master", masterVolume);
        else
            master.SetFloat("Master", 0);
    }

    public void FadeChange(bool active, bool loadNextLevel)
    {
        if (fadeIsActive == active)
            return;

        if (fadeRoutine != null)
            StopCoroutine(fadeRoutine);
        StartCoroutine(FadeUpdate(active, loadNextLevel));
        fadeIsActive = active;
    }

    private IEnumerator FadeUpdate(bool active, bool loadNextLevel)
    {
        float _timer;
        if (active)
            _timer = 0;
        else
            _timer = fadeDuration;

        while (active && _timer < fadeDuration || !active && _timer > 0)
        {
            if (active)
                _timer += 0.1f;
            else
                _timer -= 0.1f;
            yield return new WaitForSeconds(0.1f);

            fade.color = new Color(0, 0, 0, _timer / fadeDuration);
            master.SetFloat("Master", Mathf.Lerp(masterVolume, 0, _timer / fadeDuration));
        }

        fadeRoutine = null;
        if (loadNextLevel)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
