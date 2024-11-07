using UnityEngine;

public class HealthCharacter : MonoBehaviour
{
    [SerializeField] private int _maxValue;

    private float _minValue = 0;

    public int CurrentValue { get; private set; }

    private void Awake()
    {
        CurrentValue = _maxValue;
    }    

    public void TakeDamage(int damage)
    {
        if (damage > 0)
            CurrentValue -= damage;

        Mathf.Clamp(CurrentValue, _minValue, _maxValue);
    }

    public void Restore(int value)
    {
        if (value > 0)
            CurrentValue += value;

        Mathf.Clamp(CurrentValue, _minValue, _maxValue);
    }
}
