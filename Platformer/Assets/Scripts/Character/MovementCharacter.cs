using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MovementCharacter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] CheckGround _checkGround;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private bool _isMoving;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moving = Input.GetAxis("Horizontal");

        transform.position += transform.right * moving * _speed * Time.deltaTime;

        if (moving != 0 ? true : false)
            _spriteRenderer.flipX = moving < 0 ? true : false;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _checkGround.IsGrounded)
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }
}
