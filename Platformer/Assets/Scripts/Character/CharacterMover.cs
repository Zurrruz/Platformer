using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private ControllerGroundPosition _controllerGroundPosition;
    [SerializeField] private InputParameters _inputParameters;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool _isJump = false;

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
        CheckAvailabilityJump();
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

    private void CheckAvailabilityJump()
    {
        if (_inputParameters.IsJump && _controllerGroundPosition.IsGrounded)
            _isJump = true;
    }

    private void Jump()
    {
        if (_isJump)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            _isJump= false;
        }
    }
}
