using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _keyCodeAttack;
    [SerializeField] private KeyCode _keyCodeJump;
    [SerializeField] private KeyCode _keyCodeVampirismAttack;
    private string _axis = "Horizontal";

    public float Moving => Input.GetAxis(_axis);
    public bool IsAttacking => Input.GetKeyDown(_keyCodeAttack);
    public bool IsJump => Input.GetKeyDown(_keyCodeJump);
    public bool IsVampirismAttack => Input.GetKeyDown(_keyCodeVampirismAttack);
}
