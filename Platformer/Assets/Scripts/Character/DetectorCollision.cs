using System;
using UnityEngine;

public class DetectorCollision : MonoBehaviour
{
    public event Action<MedicineBox> Picked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            if (item is MedicineBox medicineBox)
            {
                Picked?.Invoke(medicineBox);
                Destroy(item.gameObject);
            }

            if(item is Coin coin)
                coin.Delete();
        }
    }
}
