using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private InputParameters _inputParameters;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool _canJump = false;

    private Rigidbody2D _rigidbody;

    private Vector3 _lookLeft = new(-1, 1, 1);
    private Vector3 _lookRight = new(1, 1, 1);

    private bool _isMoving;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void Update()
    {
        Move();
        AllowsJump();
    }

    private void Move()
    {
        transform.position += transform.right * _inputParameters.Moving * _speed * Time.deltaTime;

        if (_inputParameters.Moving != 0)
        {
            if (_inputParameters.Moving < 0)
                transform.localScale = _lookLeft;
            else 
                transform.localScale = _lookRight;
        }
    }

    private void AllowsJump()
    {
        if (_inputParameters.IsJump && _groundDetector.IsGrounded)
            _canJump = true;
    }

    private void Jump()
    {
        if (_canJump)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            _canJump= false;
        }
    }
}
