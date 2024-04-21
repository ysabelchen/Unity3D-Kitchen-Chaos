using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu()] only want to create one, so this line is commented out so we can't create another in the project files menu
public class RecipeListSO : ScriptableObject {

    public List<RecipeSO> recipeSOList;

}