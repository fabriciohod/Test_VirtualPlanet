using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class IngredientsPreview : MonoBehaviour
{
    [SerializeField] RectTransform iconsPanel;
    [SerializeField] Icon iconPrefab;

    List<Icon> previousRecipe = new List<Icon>();

    void OnEnable()
    {
        GameManager.OnReceiveOrder += ShowRecipe;
        GameManager.OnDelivery += ClearRecipe;
    }

    void OnDisable()
    {
        GameManager.OnReceiveOrder -= ShowRecipe;
        GameManager.OnDelivery -= ClearRecipe;
    }

    public void ShowRecipe(RecipesSO so)
    {
        for (int i = 0; i < so.recipe.Count; i++)
        {
            Icon instance = Instantiate(iconPrefab, iconsPanel);
            instance.SetIcon(so.recipe[i].icon);

            previousRecipe.Add(instance);            
        }
    }

    public void ClearRecipe()
    {
        for (int i = 0; i < previousRecipe.Count; i++)
            previousRecipe[i].Remove();
        
        previousRecipe.Clear();
    }
}
