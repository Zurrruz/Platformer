using UnityEngine;

public class InputParameters : MonoBehaviour
{
    [SerializeField] private KeyCode _keyCodeAttack;
    [SerializeField] private KeyCode _keyCodeJump;
    private string _axis = "Horizontal";

    public float Moving { get; private set; }
    public bool IsAttacking {  get; private set; }
    public bool IsJump { get; private set; }

    private void Update()
    {
        Moving = Input.GetAxis(_axis);
        IsAttacking = Input.GetKeyDown(_keyCodeAttack);
        IsJump = Input.GetKeyDown(_keyCodeJump);
    }
}
