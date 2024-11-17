using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health _healthCharacter;

    public abstract void Show();
}
