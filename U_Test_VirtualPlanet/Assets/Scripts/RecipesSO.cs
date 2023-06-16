using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "SO/Create Recipe")]
public class RecipesSO : ScriptableObject
{
    [SerializeField] List<Ingredient> recipe;

    public bool Compere(List<Ingredient> sandwich)
    {
        return recipe.SequenceEqualIgnoreOrder(sandwich);
    }
}
