using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static event Action OnClearTable;
    [field: SerializeField] public Transform SpawnPoint { get; private set; }
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

    [ContextMenu("Test Compare")]
    void TestCompare() => Debug.Log(recipe.Compere(sandwich));
}
