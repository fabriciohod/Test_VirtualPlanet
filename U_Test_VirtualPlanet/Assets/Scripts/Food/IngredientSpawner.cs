using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Pool;

public class IngredientSpawner : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Ingredient ingredient;
    ObjectPool<Ingredient> pool;

    void Awake()
    {
        pool = new ObjectPool<Ingredient>(Create, OnGet, Release, DestroyObj, true, 10, 20);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Ingredient temp = pool.Get();
        temp.SetPool(pool);
        temp.transform.position = GameManager.Instance.SpawnPoint.position;

        GameManager.Instance.sandwich.Add(ingredient);
    }

    Ingredient Create() => Instantiate(ingredient);

    void OnGet(Ingredient instance)
    {
        if (instance != ingredient)
            return;

        instance.gameObject.SetActive(true);
    }

    void Release(Ingredient instance)
    {
        if (instance != ingredient)
            return;

        instance.gameObject.SetActive(false);
    }

    void DestroyObj(Ingredient instance)
    {
        if (instance != ingredient)
            return;

        DestroyImmediate(instance);
    }
}
