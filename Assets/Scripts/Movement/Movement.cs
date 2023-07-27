using UnityEngine;

namespace Movement
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _boundaryPadding = 0.1f;
        [SerializeField] private Transform _finishLine;

        private float _minX, _maxX, _minY, _maxY;

        private void Start()
        {
            CalculateMovementBounds();
        }

        private void Update()
        {
            HandleInput();
        }

        private void CalculateMovementBounds()
        {
            var mainCamera = Camera.main;
            if (mainCamera != null)
            {
                var screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
                _minX = -screenBounds.x + _boundaryPadding;
                _maxX = screenBounds.x - _boundaryPadding;
                _minY = -screenBounds.y + _boundaryPadding;
            }

            _maxY = _finishLine.position.y - _boundaryPadding - _finishLine.localScale.y/2;
        }

        private void HandleInput()
        {
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");
            if (moveHorizontal == 0 && moveVertical == 0) return;

            var newPosition = transform.position + new Vector3(moveHorizontal, moveVertical, 0) * _moveSpeed * Time.deltaTime;
        
            transform.localScale = moveHorizontal < 0 ? new Vector3(-1f, 1f, 1f) : new Vector3(1f, 1f, 1f);

            newPosition.x = Mathf.Clamp(newPosition.x, _minX+transform.localScale.x/2, _maxX-transform.localScale.x/2);
            newPosition.y = Mathf.Clamp(newPosition.y, _minY+transform.localScale.y/2, _maxY-transform.localScale.y/2);

            transform.position = newPosition;
        }
    }
}
