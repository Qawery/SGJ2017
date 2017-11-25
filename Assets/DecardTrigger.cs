using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class DecardTrigger : MonoBehaviour
{
    public IdentificationLottery LotteryCanvas;

    void OnTriggerEnter(Collider other)
    {
        var bag = other.GetComponent<ItemBag>();
        if (bag != null)
        {
            if (bag.CarriedWeapon != null)
            {
                if (LotteryCanvas.isActiveAndEnabled == false)
                {
                    LotteryCanvas.SetWeaponCore(bag.CarriedWeapon, other.gameObject);
                    bag.CarriedWeapon = null;
                }
                Debug.Log("Dont approach when im busy");
            }
            Debug.Log("Player, but no item");
        }
    }
}
