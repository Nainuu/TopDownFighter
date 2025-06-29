using UnityEngine;
using DG.Tweening;
public class MenuAnimator : MonoBehaviour
{
    public RectTransform gameOverview;
    public RectTransform eqptOverview;
    public RectTransform charOverview;

    public RectTransform newGame;
    public RectTransform resumeGame;
    public RectTransform settings;

    Vector2 gameOverviewStart;
    Vector2 eqptOverviewStart;
    Vector2 charOverviewStart;

    Vector2 newGameStart;
    Vector2 resumeGameStart;
    Vector2 settingsStart;

    void Start()
    {
        // Save original positions
        gameOverviewStart = gameOverview.anchoredPosition;
        eqptOverviewStart = eqptOverview.anchoredPosition;
        charOverviewStart = charOverview.anchoredPosition;

        newGameStart = newGame.anchoredPosition;
        resumeGameStart = resumeGame.anchoredPosition;
        settingsStart = settings.anchoredPosition;

        AnimateTopMenu();
        AnimateBottomButtons();
    }

    void AnimateTopMenu()
    {
        gameOverview.anchoredPosition = gameOverviewStart + new Vector2(-500, 0);
        eqptOverview.anchoredPosition = eqptOverviewStart + new Vector2(0, 300);
        charOverview.anchoredPosition = charOverviewStart + new Vector2(500, 0);

        gameOverview.DOAnchorPos(gameOverviewStart, 1f).SetEase(Ease.OutBack);
        eqptOverview.DOAnchorPos(eqptOverviewStart, 1f).SetEase(Ease.OutBack).SetDelay(0.2f);
        charOverview.DOAnchorPos(charOverviewStart, 1f).SetEase(Ease.OutBack).SetDelay(0.4f);
    }

    void AnimateBottomButtons()
    {
        newGame.anchoredPosition = newGameStart + new Vector2(-600, 0);
        resumeGame.anchoredPosition = resumeGameStart + new Vector2(-600, 0);
        settings.anchoredPosition = settingsStart + new Vector2(-600, 0);

        newGame.DOAnchorPos(newGameStart, 1.2f).SetEase(Ease.OutExpo).SetDelay(0.7f);
        resumeGame.DOAnchorPos(resumeGameStart, 1.2f).SetEase(Ease.OutExpo).SetDelay(0.9f);
        settings.DOAnchorPos(settingsStart, 1.2f).SetEase(Ease.OutExpo).SetDelay(1.1f);
    }
}
