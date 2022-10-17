using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private float _distance;
    [SerializeField] private float _speed;
    [SerializeField] private Cube _prefab;
    [SerializeField] private Transform _endPoint;

    public void OnSpeedInput(float newSpeed) => _speed = newSpeed;

    public void OnDistanceInput(float newDistance)
    {
        _distance = newDistance;
        _endPoint.position = transform.position + _distance * Vector3.right;
    }
    public void OnTimeInput(float newTime) => _spawnCooldown = newTime;

    private void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    private IEnumerator SpawnTimer()
    {
        yield return new WaitForSecondsRealtime(_spawnCooldown);
        Spawn();
        StartCoroutine(SpawnTimer());
    }

    private void Spawn()
    {
        GameObject inst = Instantiate(_prefab.gameObject);
        inst.GetComponent<Cube>().Initialize(_speed, _distance);
        inst.transform.position = transform.position;
    }
}
