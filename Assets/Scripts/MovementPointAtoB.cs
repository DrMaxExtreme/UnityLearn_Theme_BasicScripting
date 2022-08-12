using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPointAtoB : MonoBehaviour
{
    [SerializeField] private Transform _a;
    [SerializeField] private Transform _b;
    [SerializeField] private Transform _target;

    private void Update()
    {
        _target.position = Vector3.Lerp(_target.position, _b.position, 0.003f);
    }

    public void SetNormalizedPosition(float position)
    {
        _target.position = Vector3.Lerp(_a.position, _b.position, position);
    }
}
