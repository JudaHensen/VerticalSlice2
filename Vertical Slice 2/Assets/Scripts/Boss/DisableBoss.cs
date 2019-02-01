using UnityEngine;


public class DisableBoss : MonoBehaviour {

    public BossAI bossAi;
    private BossAnimations bossAnimations;
    private BossAttack bossAttack;
    
    private float maxY = -10f;
    private float speed = -0.9f;

    private void Start()
    {
        bossAttack = GetComponent<BossAttack>();
        bossAnimations = GetComponent<BossAnimations>();
    }

    public void Descend()
    {
        DisableEnabled();
        Invoke("MoveCorpse", 2f);
    }

    void DisableEnabled()
    {
        bossAnimations.enabled = false;
        bossAttack.enabled = false;
        bossAi.enabled = false;
    }

    void MoveCorpse()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));


        if (transform.position.y <= maxY)
            Destroy(gameObject);

        Invoke("MoveCorpse", 0.01f);
    }

}
