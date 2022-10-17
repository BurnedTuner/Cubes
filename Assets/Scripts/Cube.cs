using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;

    [SerializeField] private Vector3 _endPoint;

    public void Initialize(float speed, float distance)
    {
        _distance = distance;
        _speed = distance > 0? speed : -speed;
        _endPoint = transform.position + _distance * Vector3.right;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.right * _speed * Time.fixedDeltaTime;
        if (Mathf.Abs(_endPoint.x - transform.position.x) <= Mathf.Abs(_speed) * Time.fixedDeltaTime)
            Destroy(gameObject);
    }
}
