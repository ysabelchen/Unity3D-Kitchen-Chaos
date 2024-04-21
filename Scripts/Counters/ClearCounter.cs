using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter {
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player) {
        if (!HasKitchenObject()) { // If the ClearCounter doesn't have a KitchenObject
            if (player.HasKitchenObject()) { // Then if the Player is carrying a KitchenObject
                // Drop the KitchenObject that the Player is carrying and put it on the counter
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        } else { // If the ClearCounter has a KitchenObject
            if (!player.HasKitchenObject()) { // Then if the Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            } else {
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) { // If the Player is holding a Plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())) {
                        GetKitchenObject().DestroySelf();
                    }
                } else { // If Player is carrying something that is not a Plate
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject)) { // Then if counter is holding a Plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }

        }
    }
}
