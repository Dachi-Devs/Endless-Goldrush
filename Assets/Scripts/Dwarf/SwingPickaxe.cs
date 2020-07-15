using UnityEngine;

public class SwingPickaxe : MonoBehaviour
{
    [SerializeField]
    private LayerMask floorLayer;
    [SerializeField]
    private LayerMask obstacleLayer;

    private Rigidbody2D rb2d;

    [SerializeField]
    private GameObject pickaxe;
    
    [SerializeField]
    private float jumpForce;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        FindObjectOfType<PickAnimController>().OnSwingEnd += AnimController_OnSwingEnd;
        if (rb2d == null)
        {
            rb2d = gameObject.AddComponent<Rigidbody2D>();
        }
        //GetAnimControllerWhenMade
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponentInChildren<PickAnimController>().StartSwing();
        }
    }

    private void AnimController_OnSwingEnd(object sender, System.EventArgs e)
    {
        if (IsMining())
        {
            Debug.Log("MINE");
            Mine();
        }
        else if (IsGrounded())
        {
            Debug.Log("JUMP");
            Jump();
        }
    }

    private void Jump()
    {
        rb2d.velocity = Vector3.up * jumpForce;
    }

    private void Mine()
    {
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        RaycastHit2D ray = Physics2D.BoxCast(box.bounds.center, box.bounds.size * 5f, 0f, Vector2.right, 1f, obstacleLayer);
        
        OreProperties ore = ray.collider.GetComponent<OreProperties>();
        GameManager.instance.AddToScore(ore.GetOreValue());


        Destroy(ore.gameObject);
    }

    private bool IsGrounded()
    {
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        RaycastHit2D ray = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, 1f, floorLayer);
        return ray.collider != null;
    }

    private bool IsMining()
    {
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        RaycastHit2D ray = Physics2D.BoxCast(box.bounds.center, box.bounds.size * 2f, 0f, Vector2.right, 1f, obstacleLayer);
        return ray.collider != null;
    }
}
