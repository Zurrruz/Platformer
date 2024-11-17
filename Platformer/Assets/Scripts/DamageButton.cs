using UnityEngine;

public class DamageButton : MonoBehaviour
{
    [SerializeField] private Health _healthCharacter;
    [SerializeField] private int _damage;

    public void Hurt()
    {
        _healthCharacter.TakeDamage(_damage);
    }
}
