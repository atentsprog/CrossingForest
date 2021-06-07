using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkUI : MonoBehaviour
{
    // UI나타날때 스케일 애니메이션,
    // 알파 애니메이션
    // 위치 애니메이션하자.

    CanvasGroup canvasGroup;
    public float duration = 1f;

    public Vector2 startPosition = new Vector2( -100, 0); // 위치 애니
    public float startScale = 0.7f;
    public float startAlpha = 0;

    //인스펙터에서 확인 하는 용도
    public Vector3 originalLocalPosition;
    public Vector3 originalScale;
    public float originalAlpha;


    // 실행순서 Awake -> OnEnable -> Start -> Update
    void Awake()
    {
        //  컴포넌트 할당및 원래값 저장.
        canvasGroup = GetComponent<CanvasGroup>();
        originalLocalPosition = transform.localPosition;
        originalAlpha = canvasGroup.alpha;
        originalScale = transform.localScale;
    }

    private void OnEnable()
    {
        // 초기 설정값 지정
        transform.localPosition = originalLocalPosition + (Vector3)startPosition;
        canvasGroup.alpha = startAlpha;
        transform.localScale = originalScale * startScale;

        // 트윈 애니메이션 설정
        transform.DOLocalMove(originalLocalPosition, duration); // 위치,
        transform.DOScale(originalScale, duration); // 크기,
        canvasGroup.DOFade(originalAlpha, duration);
    }
}
