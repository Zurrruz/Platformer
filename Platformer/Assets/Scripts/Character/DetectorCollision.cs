using System;
using UnityEngine;

public class DetectorCollision : MonoBehaviour
{
    public event Action<MedicineBox> Picked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out MedicineBox medicineBox))
        {
            Picked?.Invoke(medicineBox);
            Destroy(medicineBox.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out Coin coin))
            coin.Delete();
    }
}
