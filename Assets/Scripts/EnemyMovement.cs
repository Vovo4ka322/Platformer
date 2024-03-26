using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform[] _wayPoints;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _moveSpeed;

    private int _currentPoint = 0;
    private bool _isMoving = true;

    private void Update()
    {
        Move();
        Flip();
    }

    private void Move()
    {
        if (transform.position.x == _wayPoints[_currentPoint].position.x)
            _currentPoint = (_currentPoint + 1) % _wayPoints.Length;

        transform.position = Vector2.MoveTowards(transform.position, _wayPoints[_currentPoint].position, _moveSpeed * Time.deltaTime);
    }

    private void Flip()
    {
        bool isRight = _spriteRenderer.flipX;
        var currentPosition = transform.position.x;

        if (currentPosition > transform.position.x)
        {
            isRight = true;
        }

        else
            isRight = false;

       //if(_isMoving == true)
       // {
       //     //Vector3 temp = transform.localScale;
       //     //temp.x *= -1;
       //     //transform.localScale = temp;

       //     _spriteRenderer.flipX = false;
       //     _isMoving = !_isMoving;
       // }
       // else
       // {
       //     _spriteRenderer.flipX = true;
       //     _isMoving = !_isMoving;
       // }
    }
}
