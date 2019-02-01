using UnityEngine;


public class DisablePlayer : MonoBehaviour {

    private PlayerMovement playerMovement;
    private PlayerAnimations playerAnimations;
    private PlayerAttack playerAttack;
    private Rigidbody2D rb;

    public CameraFollow cam;

    private float maxY = 15f;
    private float speed = 0.9f;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        playerAnimations = GetComponent<PlayerAnimations>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Ascend()
    {
        gameObject.tag = "Untagged";
        DisableEnabled();
        Invoke("MoveCorpse", 2f);
    }

    void DisableEnabled()
    {
        playerAnimations.enabled = false;
        playerAttack.enabled = false;
        playerMovement.enabled = false;
        rb.simulated = false;
        cam.enabled = false;
    }

    void MoveCorpse()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));


        if (transform.position.y >= maxY)
            Destroy(gameObject);

        Invoke("MoveCorpse", 0.01f);
    }

}
