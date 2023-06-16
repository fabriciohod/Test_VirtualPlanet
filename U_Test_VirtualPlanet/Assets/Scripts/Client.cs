using System;
using UnityEngine;
using UnityEngine.Playables;
using Random = UnityEngine.Random;

public class Client : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    [SerializeField] PlayableAsset exitTimeline;
    [SerializeField] RecipesSO[] orders;
    [SerializeField] Material[] variations;
    [SerializeField] SkinnedMeshRenderer meshRenderer;

    public static event Action OnBackHome;

    void Awake()
    {
    }

    void OnEnable()
    {
        GameManager.OnDelivery += PlayExit;
        meshRenderer.material = variations[Random.Range(0, 4)];
    }

    void OnDisable() => GameManager.OnDelivery -= PlayExit;

    void OnDestroy()
    {
        if(!this.gameObject.scene.isLoaded) return;
        OnBackHome?.Invoke();
    }

    private void PlayExit()
    {
        director.playableAsset = exitTimeline;
        director.Play();
    }

    public void PlaceOrder()
    {
        RecipesSO order = orders[Random.Range(0, orders.Length)];

        GameManager.Instance.ReceiveOrder(order);
    }

    public void GoHome() => Destroy(gameObject);
}
