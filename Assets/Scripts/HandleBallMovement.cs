using UnityEngine;
using UnityEngine.InputSystem;

public class HandleBallMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private InputActionAsset inputActionAsset;
    [SerializeField] private GameObject winUI;
    private GameObject _gameOverUI;
    private InputActionMap moveBallActionMap;
    private InputAction _moveBallAction;
    private Vector3 _moveDirection;
    private Rigidbody _ballRigidbody;
    private Vector3 forceVector;

    // Start is called before the first frame update
    void Start()
    {
        moveBallActionMap = inputActionAsset.FindActionMap("BallController");
        moveBallActionMap.Enable();
        _moveBallAction = moveBallActionMap.FindAction("MoveBall");
        _moveBallAction.performed += OnMoveBallActionPerformed;
        _moveBallAction.canceled += OnMoveBallActionCanceled;
        _ballRigidbody = GetComponent<Rigidbody>();
        _gameOverUI = FindObjectOfType<GameOver>(true).gameObject;
    }

    private void OnEnable()
    {
        Lava.GameOver += OnGameOver;
        Goal.Win += OnWin;
    }

    private void OnWin()
    {
        _moveDirection = Vector3.zero;
        _ballRigidbody.drag = 10f;
        winUI.SetActive(true);
    }

    private void OnGameOver()
    {
        _moveDirection = Vector3.zero;
        moveBallActionMap.Disable();
        _gameOverUI.SetActive(true);
    }

    private void OnMoveBallActionCanceled(InputAction.CallbackContext obj)
    {
        // Debug.Log($"Canceled: {obj.ReadValue<Vector2>()}");
         _moveDirection = Vector3.zero;
    }

    private void OnDisable()
    {
        moveBallActionMap.Disable();
        _moveBallAction.performed -= OnMoveBallActionPerformed;
        Lava.GameOver -= OnGameOver;
        Goal.Win -= OnWin;
    }

    private void OnMoveBallActionPerformed(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        _ballRigidbody.AddForce(new Vector3(_moveDirection.x, 0f, _moveDirection.y) * moveSpeed, ForceMode.Force);
    }
}
