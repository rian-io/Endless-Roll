using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField]
    private Material _emphasisMaterial;

    [SerializeField]
    [Min(1)]
    protected float _duration;

    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * _rotateSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagSystem.PLAYER))
        {
            Destroy(gameObject);

            ChangeMaterial(_emphasisMaterial, _duration);

            Apply();
        }
    }

    public abstract void ChangeMaterial(Material emphasisMaterial, float duration);

    public abstract void Apply();
}
