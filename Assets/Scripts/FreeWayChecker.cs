using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeWayChecker : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] ContactFilter2D _filter;
    [SerializeField] float _speed;

    private float _collisionDistanceCheck = 10;

    private readonly RaycastHit2D[] _results = new RaycastHit2D[1];

    private void FixedUpdate()
    {
        var collisionCount = _rigidbody2D.Cast(transform.right, _filter, _results, _collisionDistanceCheck);

        if(collisionCount == 0)
        {
            _rigidbody2D.velocity = transform.right * _speed;
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}
