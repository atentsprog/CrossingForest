using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastMessage : SingletonMonoBehavior<ToastMessage>
{
    [SerializeField]
    Text text;

    [SerializeField]
    CanvasGroup canvasGroup;

    public void ShowToast(string text, int duration = 2)
    {
        base.Show(true);

        // 기존에 활성화 중인 메시지가 있다면 지금 코루틴이 끝난 다음에 연속해서 보여주자.
        StartCoroutine(showToastCOR(text, duration));
    }

    private IEnumerator showToastCOR(string text,
        int duration)
    {
        Color orginalColor = this.text.color;

        this.text.text = text;
        this.text.enabled = true;

        //Fade in
        yield return fadeInAndOut(canvasGroup, true, 0.5f);

        //Wait for the duration
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            yield return null;
        }

        //Fade out
        yield return fadeInAndOut(canvasGroup, false, 0.5f);

        this.text.enabled = false;
        this.text.color = orginalColor;

        CloseFn();
    }

    IEnumerator fadeInAndOut(CanvasGroup canvasGroup, bool fadeIn, float duration)
    {
        float a, b;
        if (fadeIn)
        {
            a = 0f;
            b = 1f;
        }
        else
        {
            a = 1f;
            b = 0f;
        }

        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            canvasGroup.alpha = alpha;
            yield return null;
        }
    }
}
