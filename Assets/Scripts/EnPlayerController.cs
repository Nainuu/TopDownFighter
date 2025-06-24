using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class EnPlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 7f;
    public Vector2 moveInput;
    public EnPlayerInput EnPlayerControl;
    public InputAction Move;
    public InputAction Fire;

    public void Awake()
    {
        EnPlayerControl = new EnPlayerInput();
    }

    public void OnEnable()
    {
        Move = EnPlayerControl.Player.Move;
        Move.Enable();
        Fire = EnPlayerControl.Player.Fire;
        Fire.Enable();
        Fire.performed += onFire;

    }
    public void OnDisable()
    {
        Move.Disable();
        Fire.Disable();
        Fire.performed -= onFire;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Move.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * speed, moveInput.y * speed);
    }
    private void onFire(InputAction.CallbackContext context)
    {
        Debug.Log("fired na");
    }
    
}
