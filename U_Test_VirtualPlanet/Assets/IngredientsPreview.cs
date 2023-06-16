using UnityEngine;
using DG.Tweening;

public class IngredientsPreview : MonoBehaviour
{
    [SerializeField] RectTransform iconsPanel;
    [SerializeField] Icon iconPrefab;
    void OnEnable() => GameManager.OnClearTable += ClearRecipe;

    void OnDisable() => GameManager.OnClearTable -= ClearRecipe;

    public void ShowRecipe(RecipesSO so)
    {
        for (int i = 0; i < so.recipe.Count; i++)
        {
            Icon instance = Instantiate(iconPrefab, iconsPanel);
            instance.SetIcon(so.recipe[i].icon);

        }
    }

    public void ClearRecipe()
    {
        for (int i = 0; i < iconsPanel.childCount; i++)
        {
            iconsPanel.GetChild(i).DOScale(Vector3.zero, .4f)
                .SetEase(Ease.OutElastic)
                .OnComplete(() => Destroy(iconsPanel.GetChild(i)));
        }
    }
}
