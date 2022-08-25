using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPointAtoB : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _finishPoint;
    [SerializeField] private Transform _target;
    [SerializeField] private float _interpolation = 0.003f;

    private void Update()
    {
        _target.position = Vector3.Lerp(_target.position, _finishPoint.position, _interpolation);
    }

    public void SetNormalizedPosition(float position)
    {
        _target.position = Vector3.Lerp(_startPoint.position, _finishPoint.position, position);
    }
}
