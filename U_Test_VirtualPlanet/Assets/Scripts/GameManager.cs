using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [field: SerializeField] public Transform SpawnPoint { get; private set; }
    [SerializeField] Timer gameTimer;
    [SerializeField] RecipesSO recipe;
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
        yield return new WaitForSeconds(2f);

        gameTimer.StartTimer();
    }

    [ContextMenu("Test Compare")]
    void TestCompare() => Debug.Log(recipe.Compere(sandwich));
}
