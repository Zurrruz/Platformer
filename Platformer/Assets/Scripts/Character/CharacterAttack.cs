using System.Collections;
using UnityEngine;

public abstract class CharacterAttack : MonoBehaviour
{
    [SerializeField] protected InputReader PlayerInputController;
    [SerializeField] protected float Damage;
    [SerializeField] protected float RechargeTime;
    [SerializeField] protected float DelayTime = 0.1f;    

    protected bool CanAttack = true;

    protected WaitForSeconds Delay;
    protected WaitForSeconds RechargeTimer;
    protected WaitForSeconds Timer;

    private void Update()
    {
        Assault();
    }

    public abstract void Assault();

    protected void StartRecharge()
    {
        CanAttack = false;
        StartCoroutine(Recharge());
    }

    private IEnumerator Recharge()
    {
        yield return RechargeTimer;
        CanAttack = true;
    }
}
