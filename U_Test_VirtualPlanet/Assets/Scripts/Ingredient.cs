using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Ingredient : MonoBehaviour
{
    [field: SerializeField] public int ID { get; private set; }

    IEnumerator Start()
    {
        transform.localScale = Vector3.zero;

        yield return null;

        transform.DOScale(Vector3.one, .2f).SetEase(Ease.InBounce);
    }
}
