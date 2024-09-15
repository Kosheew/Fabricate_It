using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZooming : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Скорость масштабирования камеры камеры")]
    public float _speed = 1;
    [Tooltip("Доступный радиус масштабирования камеры")]
    public float _radius = 5;
    [Tooltip("Точка от которой считается доступный радиус перемещения камеры (если она не задана в инспекторе, то по умолчанию он определяется как компонент, на котором находится сценарий)")]
    public Transform _target;

    private Touch _touchStart;
    private Touch _touchEnd;
    private Vector3 _targetPos;

    private void Start()
    {
        if (_target == null)
        {
            _target = transform;
        }

        _targetPos = _target.position;
    }

    void Update()
    {
        if (Input.touchCount == 2)
        {
            _touchStart = Input.GetTouch(0);
            _touchEnd = Input.GetTouch(1);

            Vector2 touchStartDeltaPos = _touchStart.position - _touchStart.deltaPosition;
            Vector2 touchEndDeltaPos = _touchEnd.position - _touchEnd.deltaPosition;

            float distDeltaTouches = (touchStartDeltaPos - touchEndDeltaPos).magnitude;
            float currentDistTouchesPos = (_touchStart.position - _touchEnd.position).magnitude;

            float distance = distDeltaTouches - currentDistTouchesPos;

            Zooming(distance);
        }
    }

    private void Zooming(float value)
    {
        float height = this.transform.position.y + (value * _speed * Time.deltaTime);
        float delta = Mathf.Abs(height - _targetPos.y);

        if (delta <= _radius)
            this.transform.position = new Vector3(this.transform.position.x, height, this.transform.position.z);
    }
}
