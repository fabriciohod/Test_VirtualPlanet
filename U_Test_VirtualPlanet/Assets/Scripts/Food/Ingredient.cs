using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Ingredient : MonoBehaviour
{
    [field: SerializeField] public int ID { get; private set; }
    [field: SerializeField] public Sprite icon { get; private set; }
    [SerializeField] Rigidbody physics;

    void OnEnable()
    {
        GameManager.OnClearTable += FlayAway;
        GameManager.OnDelivery += Delivery;
    }

    void OnDisable()
    {
        GameManager.OnClearTable -= FlayAway;
        GameManager.OnDelivery -= Delivery;
    }


    IEnumerator Start()
    {
        transform.localScale = Vector3.zero;

        yield return null;

        transform.DOScale(Vector3.one, .2f).SetEase(Ease.InBounce);
    }

    public void FlayAway()
    {
        physics.AddExplosionForce(5f, Vector3.up * 4, 20f, 10f, ForceMode.Impulse);
        transform.DOScale(Vector3.zero, .6f).SetEase(Ease.OutBounce).OnComplete(() => DestroyImmediate(gameObject));
    }
    public void Delivery()
    {
        physics.AddExplosionForce(5f, Vector3.back * 4, 20f, 10f, ForceMode.Impulse);
        transform.DOScale(Vector3.zero, .6f).SetEase(Ease.OutBounce).OnComplete(() => DestroyImmediate(gameObject));
    }

    public static bool operator ==(Ingredient a, Ingredient b) => a.ID == b.ID;
    public static bool operator !=(Ingredient a, Ingredient b) => a.ID != b.ID;
}
