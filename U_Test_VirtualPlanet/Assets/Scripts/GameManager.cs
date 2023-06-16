using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static event Action OnClearTable;
    public static event Action OnDelivery;
    public static event Action<RecipesSO> OnReceiveOrder;
    public List<Ingredient> sandwich { get; private set; } = new List<Ingredient>();
    public static event Action<int> OnScoreChange;
    [field: SerializeField] public Transform SpawnPoint { get; private set; }
    [SerializeField] Timer gameTimer;
    [SerializeField] IngredientsPreview previewScreen;
    [SerializeField] Client clientPrefab;
    [SerializeField] Transform clientSpawnPoint;

    RecipesSO recipe;
    int score;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);

        gameTimer.StartTimer();
    }

    void OnEnable() => Client.OnBackHome += NextClient;

    void OnDisable() => Client.OnBackHome -= NextClient;

    public void ClearTable()
    {
        OnClearTable?.Invoke();
        sandwich.Clear();
    }

    public void DeliverySandwich()
    {
        if (!recipe.Compere(sandwich))
            return;

        OnDelivery?.Invoke();
        sandwich.Clear();

        score += 50;
        OnScoreChange?.Invoke(score);
    }

    public void ReceiveOrder(RecipesSO order)
    {
        recipe = order;
        OnReceiveOrder?.Invoke(order);
    }

    public void NextClient()
    {
        if (clientSpawnPoint == null)
            return;
        Instantiate(clientPrefab, clientSpawnPoint.position, Quaternion.identity);
    }
}
