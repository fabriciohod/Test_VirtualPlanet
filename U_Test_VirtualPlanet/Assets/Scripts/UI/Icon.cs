using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    [SerializeField] Image img;

    IEnumerator Start()
    {
        transform.localScale = Vector3.zero;

        yield return null;

        transform.DOScale(new Vector3(.5f, .7f, .7f), .2f).SetEase(Ease.InElastic);
    }

    public void SetIcon(Sprite icon) => img.sprite = icon;

    public void Remove()
    {
        transform.DOScale(Vector3.zero, .4f)
        .SetEase(Ease.OutElastic)
        .OnComplete(() => Destroy(gameObject));
    }
}
