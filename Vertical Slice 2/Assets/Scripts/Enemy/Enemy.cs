public class Enemy
{
    public string name;
    public float health;
    public float damage;
    public float attackSpeed;
    public float moveSpeed;

    public Enemy()
    {
        name = "Default Enemy";
        health = 10;
        damage = 5f;
        attackSpeed = 1.5f;
        moveSpeed = 1f;
    }

    public Enemy(string Name)
    {
        name = Name;
        health = 10;
        damage = 5f;
        attackSpeed = 1.5f;
        moveSpeed = 1f;
    }

    public Enemy(string Name, float hp, float dmg)
    {
        name = Name;
        health = hp;
        damage = dmg;
        attackSpeed = 1.5f;
        moveSpeed = 1f;
    }

    public Enemy(string Name, float hp, float dmg, float attSp, float movSp)
    {
        name = Name;
        health = hp;
        damage = dmg;
        attackSpeed = attSp;
        moveSpeed = movSp;
    }

}
