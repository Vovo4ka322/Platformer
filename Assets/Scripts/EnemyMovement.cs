using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform _player;
    [SerializeField] private float _moveSpeed;

    private int _currentPoint = 0;

    private void Update()
    {
        Move();
        TryTFlip();
        //ChasePlayer();
    }

    private void Move()
    {
        if (transform.position.x == _wayPoints[_currentPoint].position.x)
            _currentPoint = (_currentPoint + 1) % _wayPoints.Length;

        transform.position = Vector2.MoveTowards(transform.position, _wayPoints[_currentPoint].position, _moveSpeed * Time.deltaTime);
    }

    private void TryTFlip() => _spriteRenderer.flipX = (transform.position.x > _wayPoints[_currentPoint].position.x) == false;

    private void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.position, _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
