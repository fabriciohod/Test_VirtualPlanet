using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static event Action OnClearTable;
    public static event Action OnDelivery;
    public static event Action<int> OnScoreChange;
    [field: SerializeField] public Transform SpawnPoint { get; private set; }
    [field: SerializeField] public int score { get; private set; }
    [SerializeField] Timer gameTimer;
    [SerializeField] RecipesSO recipe;
    [SerializeField] IngredientsPreview previewScreen;
    public List<Ingredient> sandwich { get; private set; } = new List<Ingredient>();

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    IEnumerator Start()
    {
        previewScreen.ShowRecipe(recipe);
        yield return new WaitForSeconds(2f);

        gameTimer.StartTimer();
    }

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
}
