using System;
using System.Collections;
using UnityEngine;

public class SwordAttack : CharacterAttack
{
    [SerializeField] private DetectorEnemy _detectorEnemy;

    public event Action Attaked;

    private  void Awake()
    {
        _detectorEnemy.gameObject.SetActive(false);

        RechargeTimer = new WaitForSeconds(RechargeTime);
        Delay = new WaitForSeconds(DelayTime);
    }

    public override void Assault()
    {
        if (PlayerInputController.IsAttacking && CanAttack)
        {
            StartCoroutine(DealDamage());

            Attaked?.Invoke();
        }    
    }

    private IEnumerator DealDamage()
    {
        _detectorEnemy.gameObject.SetActive(true);

        yield return Delay;

        if (_detectorEnemy.HealthEnemy != null)
            _detectorEnemy.HealthEnemy.TakeDamage(Damage);

        _detectorEnemy.Renew();

        StartRecharge();

        _detectorEnemy.gameObject.SetActive(false);
    }    
}
