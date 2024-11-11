using UnityEngine;

namespace Game.CameraControllers
{
    public class CameraMovement : MonoBehaviour
    {

        [Header("Settings")]
        [SerializeField] private float _speed = 1;
        [SerializeField] private float _radius = 10;
        [SerializeField] private Transform _target;

        private Touch _touch;
        private Vector3 _targetPos;
        private InputController _controller;


        public void Init()
        {
            if (_target == null)
            {
                _target = this.transform;
            }

            _targetPos = _target.position;
            _controller = GetComponent<InputController>();
        }

        private void LateUpdate()
        {
            if (Input.touchCount == 1)
            {
                _touch = Input.GetTouch(0);

                if (_touch.phase == TouchPhase.Moved && !_controller.isDragging)
                {
                    Vector3 movePos = new Vector3(
                        transform.position.x + _touch.deltaPosition.x * _speed * -1 * Time.deltaTime,
                        transform.position.y,
                        transform.position.z + _touch.deltaPosition.y * _speed * -1 * Time.deltaTime);

                    Vector3 distance = movePos - _targetPos;

                    if (distance.magnitude < _radius)
                        transform.position = movePos;
                }
            }
        }
    }
}