using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [Header("Initial settings")]
    [SerializeField]
    private float _initialInclination = 5f;

    [SerializeField]
    private float _initialTimeDuration = 5f;

    [Header("Rotation Settings")]
    [SerializeField, Tooltip("Level's final angle.")]
    private float _finalInclination = 60f;

    [SerializeField, Tooltip("The time to reach the final inclination.")]
    private float _totalAnimationTime = 60f;

    [Header("HUD Data")]
    [SerializeField] HUDData hudData;

    private void Start()
    {
        transform.DORotate(
            new Vector3(_initialInclination, 0f, 0f),
            _initialTimeDuration
        ).onComplete = StartRotateMecanism;
    }

    private void Update()
    {
        hudData.setLevelAngle(transform.localEulerAngles.x);
    }

    private void OnEnable()
    {
        Player.OnPlayerDies += Terminate;
    }

    private void OnDisable()
    {
        Player.OnPlayerDies -= Terminate;
    }

    public void DecreaseInclination(float angleDecrease, float duration)
    {
        Terminate();
        StartCoroutine(DecreaseLevelInclination(5f, duration));
    }

    public void StopInclination(float duration)
    {
        Terminate();
        StartCoroutine(StopLevelInclination(duration));
    }

    private void StartRotateMecanism()
    {
        StartCoroutine(IncreaseLevelInclination());
    }

    private void Terminate()
    {
        DOTween.Clear();
        StopAllCoroutines();
    }

    private IEnumerator IncreaseLevelInclination()
    {
        if (!DOTween.IsTweening(transform))
            yield return transform.DORotate(
                new Vector3(_finalInclination, 0f, 0f), _totalAnimationTime).WaitForCompletion();
    }

    private IEnumerator DecreaseLevelInclination(float angleVariation, float duration)
    {
        if (!DOTween.IsTweening(transform))
        {
            float newAngle = gameObject.transform.localEulerAngles.x - angleVariation;
            if (newAngle < 0f) newAngle = 0;

            yield return transform.DORotate(new Vector3(newAngle, 0f, 0f), duration).WaitForCompletion();
            StartRotateMecanism();
        }
    }

    private IEnumerator StopLevelInclination(float duration)
    {
        yield return new WaitForSeconds(duration);
        StartRotateMecanism();
    }
}
