using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealt : MonoBehaviour
{

    public float enemyMaxHealth;
    float currentHealth;
    public bool drops;
    public GameObject drop;

    void Start()
    {
        currentHealth = enemyMaxHealth;
    }


    void Update()
    {

    }
    //Nesnenin health'ı <=0 olduğu zaman makeDead fonksiyonuna gidip yok edilecek.
    //Enemy nin position ve rotation 'ı dropa atanacak.
    public void addDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        if (currentHealth <= 0) makeDead();
    }
    void makeDead()
    {
        Destroy(gameObject);
        if (drops) Instantiate(drop, transform.position , transform.rotation);
    }
}
