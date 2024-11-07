using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private HealthCharacter _healthCharacter;
    [SerializeField] private DetectorCollision _detectorMedicineBox;

    private void OnEnable()
    {
        _detectorMedicineBox.Picked += RestoreHealth;
    }

    private void OnDisable()
    {
        _detectorMedicineBox.Picked -= RestoreHealth;
    }

    private void RestoreHealth(MedicineBox medicineBox)
    {
        _healthCharacter.Restore(medicineBox.NumberHealingLives);
    }
}
