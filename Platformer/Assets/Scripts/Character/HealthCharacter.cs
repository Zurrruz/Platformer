using UnityEngine;

public class HealthCharacter : MonoBehaviour
{
    [SerializeField] private DetectorCollision _detectorMedicineBox;
    [SerializeField] private int _maxHealth;

    private float _minHealth = 0;

    public int Health { get; private set; }

    private void Awake()
    {
        Health = _maxHealth;
    }
    private void OnEnable()
    {
        _detectorMedicineBox.Picked += ChangesHealth;
    }

    private void OnDisable()
    {
        _detectorMedicineBox.Picked -= ChangesHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
            Health -= damage;

        Mathf.Clamp(Health, _minHealth, _maxHealth);
    }

    public void ChangesHealth(MedicineBox medicineBox)
    {
        if (medicineBox.NumberHealingLives > 0)
            Health += medicineBox.NumberHealingLives;

        Mathf.Clamp(Health, _minHealth, _maxHealth);
    }
}
