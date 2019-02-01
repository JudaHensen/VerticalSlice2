using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private BossAI bossAi;
    private PlayerHit playerHit;

    private float range;
    public static bool isAttacking = false;

    void Start()
    {
        playerHit = FindObjectOfType<PlayerHit>();
        bossAi = FindObjectOfType<BossAI>();
    }

    void Update()
    {
        range = bossAi.GetRange();

        if (range <= Boss.attackRange)
        {
            isAttacking = true;
            Invoke("Stop", 1.75f);
        }
    }

    public void Attack()
    {
        if (range < Boss.followRange - 1f)
        {
            Player.health -= Boss.damage;
            playerHit.PlayerHitAnim();
        }
    }

    void Stop()
    {
        isAttacking = false;
    }

}
