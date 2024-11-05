using System.Collections;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private InputParameters _playerInputController;
    [SerializeField] private DetectorEnemy _detectorEnemy;
    [SerializeField] private CooldownAttack _cooldownAttack;
    [SerializeField] private int _damage;

    private void Awake()
    {
        _detectorEnemy.gameObject.SetActive(false); 
    }

    private void Update()
    {
        Assault();
    }

    private void Assault()
    {
        if (_playerInputController.IsAttacking && _cooldownAttack.CanAttack)
        {
            StartCoroutine(DealDamage());
        }
    }

    private IEnumerator DealDamage()
    {
        _detectorEnemy.gameObject.SetActive(true);

        yield return null;

        if (_detectorEnemy.Enemy != null)
            _detectorEnemy.Enemy.TakeDamage(_damage);

        _cooldownAttack.StartRecharge();

        _detectorEnemy.gameObject.SetActive(false);
    }
}
