using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField]
    private Material _defaultMaterial;

    [SerializeField]
    private Renderer _renderer;

    public void ChangeMaterial(Material material, float duration)
    {
        StartCoroutine(ChangeMaterialCoroutine(material, duration));
    }

    private IEnumerator ChangeMaterialCoroutine(Material material, float duration)
    {
        _renderer.material = material;
        yield return new WaitForSeconds(duration);
        _renderer.material = _defaultMaterial;
    }
}
