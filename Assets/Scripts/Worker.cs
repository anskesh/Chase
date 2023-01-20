using System;
using UnityEngine;

public class Worker : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 4f;
    
    private void Update()
    {
        transform.Translate(Vector2.right * _movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Finish"))
            enabled = false;
    }
}
