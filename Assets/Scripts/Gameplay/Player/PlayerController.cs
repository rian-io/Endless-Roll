using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidBody;

    private PlayerInput _playerInput;

    [SerializeField]
    private float _forceModifier = 1.5f;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        Player.OnPlayerDies += StopPlayer;
        UIController.OnPause += OnPause;
    }

    private void OnDisable()
    {
        Player.OnPlayerDies -= StopPlayer;
        UIController.OnPause -= OnPause;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        float x = context.ReadValue<Vector2>().x * _forceModifier;
        _rigidBody.AddForce(new Vector3(x, -1f, 0f));
    }

    private void OnPause(bool paused)
    {
        _playerInput.enabled = !paused;
    }

    private void StopPlayer()
    {
        _playerInput.DeactivateInput();

        _rigidBody.velocity = Vector3.zero;
        _rigidBody.angularVelocity = Vector3.zero;

        _rigidBody.useGravity = false;
    }
}
