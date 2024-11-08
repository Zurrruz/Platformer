using System;
using System.Collections;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private InputReader _playerInputController;
    [SerializeField] private DetectorEnemy _detectorEnemy;
    [SerializeField] private int _damage;
    [SerializeField] private float _rechargeTime;

    private float _delayTime = 0.2f;

    private WaitForSeconds _time;
    private WaitForSeconds _delay;

    public event Action Attaked;

    public bool CanAttack { get; private set; } = true; 

    private void Awake()
    {
        _detectorEnemy.gameObject.SetActive(false);

        _time = new WaitForSeconds(_rechargeTime);
        _delay = new WaitForSeconds(_delayTime);
    }

    private void Update()
    {
        Assault();
    }

    private void Assault()
    {
        if (_playerInputController.IsAttacking && CanAttack)
        {
            StartCoroutine(DealDamage());

            Attaked?.Invoke();
        }    
    }

    private IEnumerator DealDamage()
    {
        _detectorEnemy.gameObject.SetActive(true);

        yield return _delay;

        if (_detectorEnemy.HealthEnemy != null)
            _detectorEnemy.HealthEnemy.TakeDamage(_damage);      
        
        _detectorEnemy.Renew();

        StartRecharge();

        _detectorEnemy.gameObject.SetActive(false);
    }

    public void StartRecharge()
    {
        CanAttack = false;

        StartCoroutine(Recharge());
    }

    private IEnumerator Recharge()
    {
        yield return _time;

        CanAttack = true;
    }
}
