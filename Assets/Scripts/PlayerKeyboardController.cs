using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardController : MonoBehaviour
{

    public PlayerMovement Player;

    private void Start()
    {

        Player = Player == null ? GetComponent<PlayerMovement>() : Player;
        if (Player == null)
        {
            Debug.LogError("Player not set to controller");
        }
    }

    private void Update()
    {

        if (Player != null)
        {

            if (Input.GetKey(KeyCode.D))
            {
                Player.Move();
            }
            if (Input.GetKey(KeyCode.A))
            {
                Player.Move();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Player.Jump();
            }
        }
    }
}