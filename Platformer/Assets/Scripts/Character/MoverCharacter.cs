using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoverCharacter : MonoBehaviour
{
    [SerializeField] private ControllerGroundPosition _controllerGroundPosition;
    [SerializeField] private InputParameters _inputParameters;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;

    private Vector3 _lookLeft = new(-1, 1, 1);
    private Vector3 _lookRight = new(1, 1, 1);

    private bool _isMoving;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
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

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _controllerGroundPosition.IsGrounded)
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }
}
