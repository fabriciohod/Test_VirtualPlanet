using UnityEngine.EventSystems;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Ingredient ingredient;

    public void OnPointerClick(PointerEventData eventData)
    {
        Instantiate(ingredient, GameManager.Instance.SpawnPoint.position, Quaternion.identity);
        GameManager.Instance.sandwich.Add(ingredient);
    }
}
