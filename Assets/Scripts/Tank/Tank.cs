using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private float _delayBetweenShots;
    [SerializeField] private float _recoilDistance;

    private float _timeAfterShot;

    private void Update()
    {
        _timeAfterShot += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (_timeAfterShot > _delayBetweenShots)
            {
                Shoot();
                transform.DOMoveZ(transform.position.z - _recoilDistance, _delayBetweenShots / 2).SetLoops(2, LoopType.Yoyo);
                _timeAfterShot = 0;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(_bulletTemplate, _shotPoint.position, Quaternion.identity);
    }
}
