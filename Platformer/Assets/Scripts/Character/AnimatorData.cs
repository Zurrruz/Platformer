using UnityEngine;

public static class AnimatorData
{
    public static class Params
    {
        public static readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));
        public static readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));

        public static readonly int AttackEnemy = Animator.StringToHash(nameof(AttackEnemy));
        public static readonly int IsIdle = Animator.StringToHash(nameof(IsIdle));
    }
}
