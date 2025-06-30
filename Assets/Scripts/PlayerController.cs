using JetBrains.Annotations;
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

    // animations
    public Animator animator;
    public AttackManager attackManager;

    // Track the current facing direction
    private Vector3 currentFacing = Vector3.right;




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
        animator.SetFloat("speed", Mathf.Abs(MoveInput.magnitude));
        // direction of player
        if (MoveInput.x > 0.01f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);         // Facing right
            currentFacing = Vector3.right;
        }
        else if (MoveInput.x < -0.01f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);       // Facing left (rotated around Y)
            currentFacing = Vector3.left;
        }
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Handle attack logic here
            Debug.Log("Attack performed");
            animator.SetTrigger("AttackMelee");
            
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            animator.SetTrigger("Die");
            this.enabled = false;
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
            animator.SetTrigger("Hurt");
        }
    }
}
