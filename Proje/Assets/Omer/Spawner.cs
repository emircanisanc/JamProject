using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    float timer;
    [SerializeField] float timeBetweenShots;
    [SerializeField] Type type;
    Projectile projectile;
    enum Type{
        Right,
        left
    };
    void Start()
    {
        timer = timeBetweenShots;
    }

    
    void Update()
    {
        Shoot();

        timer -= Time.deltaTime;
    }

    void Shoot()
    {
        if(timer <= 0)
        {
            var obj = Instantiate(projectilePrefab , transform.position , Quaternion.identity);
            projectile = obj.GetComponent<Projectile>();

            if(type == Type.Right)
                projectile.rb.velocity = Vector2.right * projectile.speed;
            else
                projectile.rb.velocity = Vector2.left * projectile.speed;

            timer = timeBetweenShots;
        }
    }
}
