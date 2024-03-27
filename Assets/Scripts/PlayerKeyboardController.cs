using UnityEngine;

public class PlayerKeyboardController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;

    private void Start()
    {
        _player = _player == null ? GetComponent<PlayerMovement>() : _player;
        if (_player == null)
        {
            Debug.LogError("Player not set to controller");
        }
    }

    private void Update()
    {
        if (_player != null)
        {
            if (Input.GetKey(KeyCode.D))
            {
                _player.Move();
            }
            if (Input.GetKey(KeyCode.A))
            {
                _player.Move();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _player.Jump();
            }
        }
    }
}