using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.Events;

public class InGameBtn : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent OnClicked;
    [SerializeField] Timer cooldown;
    Transform btn;
    bool canClickAgain = true;

    void Awake()
    {
        btn = transform.GetChild(0);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        btn.DOLocalMoveY(.3f, .1f).SetEase(Ease.InCubic);
        OnClicked?.Invoke();
        canClickAgain = false;
        cooldown.StartTimer(() => canClickAgain = true);
        btn.DOLocalMoveY(.5f, .1f).SetEase(Ease.OutCubic).SetDelay(.35f);
    }
}
