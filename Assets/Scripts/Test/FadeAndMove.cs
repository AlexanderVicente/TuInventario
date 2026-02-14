using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeAndMove : MonoBehaviour
{
    public Image myImage; 
    public RectTransform myImageRect; 
    [SerializeField] float moveDistance; 
    public float fadeTime = 1f; 
    public float delayBeforeMove = 3f;
    [SerializeField] float moveTime;

    private Vector2 originalPosition;

    private void OnEnable()
    {

        originalPosition = myImageRect.anchoredPosition;

        myImage.gameObject.SetActive(true);

        Sequence sequence = DOTween.Sequence();

        sequence.Append(myImage.DOFade(1f, fadeTime)) 
                .AppendInterval(delayBeforeMove) 
                .Append(myImageRect.DOAnchorPosX(myImageRect.anchoredPosition.x + moveDistance, moveTime))
                .AppendCallback(() => myImage.gameObject.SetActive(false));
    }

    private void OnDisable()
    {
        myImage.gameObject.SetActive(false);
        myImage.DOFade(0f, 0f);
        myImageRect.DOAnchorPos(originalPosition, 0f);


    }
}
