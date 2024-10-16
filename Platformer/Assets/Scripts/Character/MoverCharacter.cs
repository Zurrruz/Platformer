using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MoverCharacter : MonoBehaviour
{
    [SerializeField] private ControllerGroundPosition _controllerGroundPosition;
    [SerializeField] private PlayerInputController _controllerInput;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private bool _isMoving;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        transform.position += transform.right * _controllerInput.Moving * _speed * Time.deltaTime;

        if (_controllerInput.Moving != 0)
            _spriteRenderer.flipX = _controllerInput.Moving < 0;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _controllerGroundPosition.IsGrounded)
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }
}
