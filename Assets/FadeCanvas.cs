using System.Collections;
using UnityEngine;

/// <summary>
/// Fades a canvas over time using a coroutine and a canvas group
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
public class FadeCanvas : MonoBehaviour
{
    [Tooltip("The speed at which the canvas fades")]
    public float defaultDuration = 2.0f;

    public Coroutine CurrentRoutine { private set; get; } = null;

    private CanvasGroup canvasGroup = null;
    private float alpha = 0.0f;

    private float quickFadeDuration = 0.75f;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        Debug.Log("FadeCanvas is alive");
    }

    public void StartFadeIn()
    {
        StopAllCoroutines();
        CurrentRoutine = StartCoroutine(FadeIn(defaultDuration));
    }

    public void StartFadeOut()
    {
        StopAllCoroutines();
        CurrentRoutine = StartCoroutine(FadeOut(defaultDuration));
    }

    public void QuickFadeIn()
    {
        StopAllCoroutines();
        CurrentRoutine = StartCoroutine(FadeIn(quickFadeDuration));
    }

    public void QuickFadeOut()
    {
        StopAllCoroutines();
        CurrentRoutine = StartCoroutine(FadeOut(quickFadeDuration));
    }

    private IEnumerator FadeIn(float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            SetAlpha(t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        SetAlpha(1f);  // ensure perfect final value
    }

    private IEnumerator FadeOut(float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            SetAlpha(1f - t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        SetAlpha(0f); // ensure perfect final value
    }

    private void SetAlpha(float value)
    {
        alpha = value;
        canvasGroup.alpha = alpha;
    }
}