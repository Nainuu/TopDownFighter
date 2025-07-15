using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class EnPlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 7f;
    public float baseSpeed = 7f;
    public float actualSpeed = 7f;
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
        int difficulty = PlayerPrefs.GetInt("Difficulty", 7);
        switch (difficulty)
        {
            case 0: // Easy
                actualSpeed = baseSpeed * 0.75f;
                break;
            case 1: // Medium
                actualSpeed = baseSpeed * 1.0f;
                break;
            case 2: // Hard
                actualSpeed = baseSpeed * 1.5f;
                break;
        }
    }

    void Update()
    {
        // You can add code here if needed
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * actualSpeed, moveInput.y * actualSpeed);
    }

    private void onFire(InputAction.CallbackContext context)
    {
        Debug.Log("fired na");
    }
    
}
