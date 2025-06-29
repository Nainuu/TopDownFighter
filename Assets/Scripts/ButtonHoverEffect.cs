using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    private Color originalColor;
    public RawImage rawImage;

    [Header("Effect Settings")]
    public float scaleAmount = 1.1f;
    public float duration = 0.2f;
    public Color hoverColor = new Color(0.2f, 0.0313f, 0.0981f, 1f);

    void Start()
    {
        originalScale = transform.localScale;

        if (rawImage != null)
            originalColor = rawImage.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(originalScale * scaleAmount, duration).SetEase(Ease.OutBack);

        if (rawImage != null)
            rawImage.DOColor(hoverColor, duration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(originalScale, duration).SetEase(Ease.OutBack);

        if (rawImage != null)
            rawImage.DOColor(originalColor, duration);
    }
}