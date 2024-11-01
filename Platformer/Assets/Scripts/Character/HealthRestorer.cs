using UnityEngine;

public class HealthRestorer : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private DetectorMedicineBox _detectorMedicineBox;

    private void OnEnable()
    {
        _detectorMedicineBox.Picked += HealMedicineBox;
    }

    private void OnDisable()
    {
        _detectorMedicineBox.Picked -= HealMedicineBox;
    }

    private void HealMedicineBox(MedicineBox medicineBox)
    {        
        _character.ChangesHealth(medicineBox.NumberHealingLives);
    }
}
