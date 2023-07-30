using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action OnPlayerDies;

    [SerializeField]
    private Material _defaultMaterial;

    [SerializeField]
    private Renderer _renderer;

    [SerializeField]
    private bool _isIndestructible;

    private void OnTriggerEnter(Collider other)
    {
        if (_isIndestructible && other.gameObject.CompareTag(TagSystem.OBSTACLE))
        {
            Destroy(other.gameObject);
            return;
        }

        if (other.gameObject.CompareTag(TagSystem.OBSTACLE) ||
            other.gameObject.CompareTag(TagSystem.LEVEL_LIMIT))
        {
            Destroy(gameObject);
            StopAllCoroutines();
            // TODO start game over particles in every object listener.
            OnPlayerDies?.Invoke();
        }
    }

    public void ChangeMaterial(Material material, float duration)
    {
        StartCoroutine(ChangeMaterialCoroutine(material, duration));
    }

    public void TurnIndestructible(float duration)
    {
        _isIndestructible = true;
        StartCoroutine(IndestructibleTimerCoroutine(duration));
    }

    private IEnumerator ChangeMaterialCoroutine(Material material, float duration)
    {
        _renderer.material = material;
        yield return new WaitForSeconds(duration);
        _renderer.material = _defaultMaterial;
    }

    private IEnumerator IndestructibleTimerCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        _isIndestructible = false;
    }
}
