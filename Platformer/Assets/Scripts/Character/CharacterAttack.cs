using System.Collections;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private InputParameters _playerInputController;
    [SerializeField] private DetectorEnemy _detectorEnemy;
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
        if (_playerInputController.IsAttacking)
            StartCoroutine(DealDamage());
    }

    IEnumerator DealDamage()
    {
        _detectorEnemy.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        if (_detectorEnemy.Enemy != null)
            _detectorEnemy.Enemy.TakeDamage(_damage);

        _detectorEnemy.gameObject.SetActive(false);
    }
}
