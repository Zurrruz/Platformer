using System;
using UnityEngine;

public class DetectorMedicineBox : MonoBehaviour
{
    public event Action<MedicineBox> Picked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out MedicineBox medicineBox))
        {
            Picked?.Invoke(medicineBox);
            Destroy(medicineBox.gameObject);
        }
    }
}
