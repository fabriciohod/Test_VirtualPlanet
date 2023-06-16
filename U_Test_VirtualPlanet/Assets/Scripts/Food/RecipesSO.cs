using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "SO/Create Recipe")]
public class RecipesSO : ScriptableObject
{
    [field: SerializeField] public List<Ingredient> recipe { get; private set; }

    public bool Compere(List<Ingredient> sandwich)
    {
        return recipe.SequenceEqualIgnoreOrder(sandwich);
    }
}
