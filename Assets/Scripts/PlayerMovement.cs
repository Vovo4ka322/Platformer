using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string HorizontalMove = nameof(HorizontalMove);
    private const string IsJumping = nameof(IsJumping);

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _groundCheckRadius;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _position;
    private float _horizontalMove;
    private bool _isGround;
    private int _jumpCount = 0;
    private int _maxJumpCount = 2;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        TryFlip();
        Jump();
        PlayAnimation();
    }

    public void Move()
    {
        _position.x = Input.GetAxis(Horizontal);
        _rigidbody2D.velocity = new Vector2(_position.x * _moveSpeed, _rigidbody2D.velocity.y);
    }

    public void Jump()
    {
        _isGround = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _ground);

        if (Input.GetKeyDown(KeyCode.Space) && (_isGround || (++_jumpCount < _maxJumpCount)))
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);

        if (_isGround)
            _jumpCount = 0;
    }

    private void TryFlip() => _spriteRenderer.flipX = (_position.x < 0) == true;

    private void PlayAnimation()
    {
        _horizontalMove = Input.GetAxis(Horizontal);
        _animator.SetFloat(HorizontalMove, Mathf.Abs(_horizontalMove));
    }
}
