using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    [SerializeField] private GameObject _body;

    [SerializeField] private ParticleSystem _particles;

    private void OnEnable()
    {
        Player.OnPlayerDies += Play;
    }

    private void OnDisable()
    {
        Player.OnPlayerDies -= Play;
    }

    public void Play()
    {
        _body.SetActive(false);
        _particles.Play();
    }
}
