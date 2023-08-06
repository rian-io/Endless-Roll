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
        UIController.OnPause += OnPause;
    }

    private void OnDisable()
    {
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
}
