using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Pool;

public class Ingredient : MonoBehaviour
{
    [field: SerializeField] public int ID { get; private set; }
    [field: SerializeField] public Sprite icon { get; private set; }
    [SerializeField] Rigidbody physics;
    ObjectPool<Ingredient> _pool;

    void Awake()
    {
        physics.velocity = Vector3.zero;
    }

    void OnEnable()
    {
        transform.localScale = Vector3.zero;
        physics.freezeRotation = false;

        transform.DOScale(Vector3.one, .2f).SetEase(Ease.InBounce);

        GameManager.OnClearTable += FlayAway;
        GameManager.OnDelivery += Delivery;
    }

    void OnDisable()
    {
        GameManager.OnClearTable -= FlayAway;
        GameManager.OnDelivery -= Delivery;

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        physics.velocity = Vector3.zero;
        physics.freezeRotation = true;
    }

    public void SetPool(ObjectPool<Ingredient> pool) => _pool = pool;

    public void FlayAway()
    {
        physics.AddExplosionForce(5f, Vector3.up * 4, 20f, 10f, ForceMode.Impulse);
        transform.DOScale(Vector3.zero, .6f).SetEase(Ease.OutBounce).OnComplete(() => _pool.Release(this));
    }
    public void Delivery()
    {
        physics.AddExplosionForce(5f, Vector3.back * 4, 20f, 10f, ForceMode.Impulse);
        transform.DOScale(Vector3.zero, .6f).SetEase(Ease.OutBounce).OnComplete(() => _pool.Release(this));
    }

    public static bool operator ==(Ingredient a, Ingredient b) => a.ID == b.ID;
    public static bool operator !=(Ingredient a, Ingredient b) => a.ID != b.ID;
}
