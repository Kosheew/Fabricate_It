using UnityEngine;

namespace Game.CameraControllers
{
    public class CameraZooming : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _speed = 1;
        [SerializeField] private float _radius = 5;
        [SerializeField] private Transform _target;

        private Touch _touchStart;
        private Touch _touchEnd;
        private Vector3 _targetPos;

        public void Init()
        {
            if (_target == null)
            {
                _target = transform;
            }

            _targetPos = _target.position;
        }

        private void LateUpdate()
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
}