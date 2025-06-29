using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public InputSystem_Actions PlayerControls;
    public Vector2 MoveInput;
    public float Speed = 5f;
    public Rigidbody2D rb;
    private InputAction Move;
    private InputAction Attack;

    public int MaxHealth = 100;
    public int currentHealth;

    public PlayerHealth healthBar;



    public void Awake()
    {
        PlayerControls = new InputSystem_Actions();
    }

    public void OnEnable()
    {
        Move = PlayerControls.Player.Move;
        Attack = PlayerControls.Player.Attack;
        Move.Enable();
        Attack.Enable();
        Attack.performed += OnAttack;
    }
    public void OnDisable()
    {
        if (Move != null)
            Move.Disable();

        if (Attack != null)
        {
            Attack.Disable();
            Attack.performed -= OnAttack;
        }
    }


    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        currentHealth = MaxHealth;
        if (healthBar)
        {
            healthBar.SetMaxHealth(MaxHealth);
        }
    }

    void Update()
    {
        MoveInput = Move.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(MoveInput.x * Speed, MoveInput.y * Speed);
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Handle attack logic here
            Debug.Log("Attack performed");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
            Debug.Log("Took damage from enemy collision");
        }
    }
}
