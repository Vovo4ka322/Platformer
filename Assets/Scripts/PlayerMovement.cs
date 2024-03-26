using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _groundCheckRadius;

    private const string Horizontal = nameof(Horizontal);
    private const string HorizontalMove = nameof(HorizontalMove);
    private const string IsJumping = nameof(IsJumping);

    private Rigidbody2D _rigidbody2D;
    private Vector2 _position;
    private float _horizontalMove;
    private bool _isGround;
    private int _jumpCount;
    private int _maxJumpCount;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _jumpCount = 0;
        _maxJumpCount = 2;
    }

    private void Update()
    {
        Move();
        Flip();
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

    private void Flip()
    {
        if (_position.x > 0)
            _spriteRenderer.flipX = false;
        else if (_position.x < 0)
            _spriteRenderer.flipX = true;
    }

    private void PlayAnimation()
    {
        _horizontalMove = Input.GetAxis(Horizontal);
        _animator.SetFloat(HorizontalMove, Mathf.Abs(_horizontalMove));
    }
}
