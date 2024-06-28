using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TotakManager : MonoBehaviour
{
    public static TotakManager instance;

    public Image fadeScreen;
    
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void MoveScene(int id)
    {
        StartCoroutine(MoveSceneWithFade(id));
    }

    public void MoveScene(string sceneName)
    {
        StartCoroutine(MoveSceneWithFade(sceneName));
    }

    private IEnumerator MoveSceneWithFade(int id)
    {
        yield return StartCoroutine(FadeScreen(true));
        SceneManager.LoadScene(id);
        yield return StartCoroutine(FadeScreen(false));
    }
    
    private IEnumerator MoveSceneWithFade(string sceneName)
    {
        yield return StartCoroutine(FadeScreen(true));
        SceneManager.LoadScene(sceneName);
        yield return StartCoroutine(FadeScreen(false));
    }

    private IEnumerator FadeScreen(bool fadeOut)
    {
        var fadeTimer = 0f;
        const float FadeDuration = 1f;

        var initialValue = fadeOut ? 0f : 1f;
        var fadeDir = fadeOut ? 1f : -1f;
        
        while (fadeTimer < FadeDuration)
        {
            yield return null;
            fadeTimer += Time.deltaTime;

            var color = fadeScreen.color;

            initialValue += fadeDir * Time.deltaTime;
            color.a = initialValue;

            fadeScreen.color = color;
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
