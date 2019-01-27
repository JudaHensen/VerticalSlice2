public class Boss : Enemy
{
    public Boss()
    {
        name = "Bosssy Boss";
        health = 300; ;
        damage = 10f;
        attackSpeed = 1.5f;
        moveSpeed = 0.2f;
    }

    public void Attack() {

    }

    public void TakeDamage(float ammount) {
        health -= ammount;
    }
}
