using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color _reaghtColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            _renderer.color = _reaghtColor;
        }
    }
}
