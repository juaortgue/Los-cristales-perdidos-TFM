using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private RandomEncounter randomEncounter;
    private Rigidbody2D rb;
    private Vector2 movement;
    private PlayerControls controls;
    public Animator animator;
    public GameObject spawnPoint;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        randomEncounter = this.gameObject.GetComponent<RandomEncounter>();

        if (GameContext.previousScene.Equals(SceneEnum.BattleScene) &&
        PlayerStats.Instance.getPlayerPosition() != Vector3.zero)
        {
            Debug.Log("Returning from battle — setting saved position.");
            transform.position = PlayerStats.Instance.getPlayerPosition();
        }
        else
        {
            Debug.Log("Using spawn point.");
            transform.position = spawnPoint.transform.position;
        }
       

    }

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Player.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => movement = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Update()
    {
        Vector2 input = controls.Player.Move.ReadValue<Vector2>();

        if (input != Vector2.zero)
        {
            animator.SetBool("isRunning", true);
            randomEncounter.SetWalking(true);
        }

        else
        {
            animator.SetBool("isRunning", false);
            randomEncounter.SetWalking(false);
        }

        if (input.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        else if (input.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }

    }

    
}
