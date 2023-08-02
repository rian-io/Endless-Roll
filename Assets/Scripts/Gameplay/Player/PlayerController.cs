using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidBody;

    [SerializeField]
    private float _forceModifier = 1.5f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        float x = context.ReadValue<Vector2>().x * _forceModifier;
        _rigidBody.AddForce(new Vector3(x, 0f, 0f));
    }
}
