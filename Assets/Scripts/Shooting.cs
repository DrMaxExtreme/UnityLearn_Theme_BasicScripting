using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);

        if (hit)
        {
            Destroy(hit.collider.gameObject);
        }
    }
}
