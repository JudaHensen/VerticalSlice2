using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public class Player
    {
        public float health;
        public float damage;
        public float attackSpeed;
        public float minSpeed;
        public float speed;
        public float maxSpeed;
        public float acceleration;
        public float maxJumpHeight;
        public float airTime;
        public float dashCoolDown;
        
        public Player()
        {
            health = 100f;
            damage = 20f;
            attackSpeed = 0.2f;
            minSpeed = 30f;
            speed = 30f;
            maxSpeed = 100f;
            acceleration = 120f;
            maxJumpHeight = 3f;
            airTime = 0.4f;
            dashCoolDown = 1f;
        }
    }
}
