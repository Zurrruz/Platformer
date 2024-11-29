using System;
using System.Collections;
using UnityEngine;

public class Vampirism : CharacterAttack
{
    [SerializeField] private Health _characterHealth; 
    [SerializeField] private ScanVampirismZone _scanVampirizmZone;
    [SerializeField] private float _spellTime;

    private Coroutine _coroutine;

    public float SpellTime => _spellTime;

    public event Action<float> Attaked;

    private void Awake()
    {
        _scanVampirizmZone.gameObject.SetActive(false);

        Timer = new WaitForSeconds(_spellTime);
        RechargeTimer = new WaitForSeconds(RechargeTime);
        Delay = new WaitForSeconds(DelayTime);
    }

    public override void Assault()
    {
        if (PlayerInputController.IsVampirismAttack && CanAttack)
        {
            StartSpell();

            Attaked?.Invoke(RechargeTime);
        }
    }

    public void StartSpell()
    {
        CanAttack = false;

        _scanVampirizmZone.gameObject.SetActive(true);

        _coroutine = StartCoroutine(TransferHealth());
        StartCoroutine(RechargeSpell());
    }

    private IEnumerator RechargeSpell()
    {
        yield return Timer;

        StopCoroutine(_coroutine);

        _scanVampirizmZone.gameObject.SetActive(false);

        StartRecharge();
    }

    private IEnumerator TransferHealth()
    {
        Health enemyHealth;

        while (enabled)
        {
            if (_scanVampirizmZone.CanSeeNearesEnemy(out enemyHealth))
            {
                enemyHealth.TakeDamage(Damage);
                _characterHealth.Restore(Damage);
            }

            yield return Delay;
        }
    }
}
