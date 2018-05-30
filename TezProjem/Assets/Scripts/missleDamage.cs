using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missleDamage : MonoBehaviour {

    public float weaponDamage;
    projectileController myPC;
   
	void Awake () {
        myPC = GetComponentInParent<projectileController>();
	}
	
	void Update () {
		
	}
    //Layer'ı shootable olan nesnelere ateş edildiğinde mermimiz kaybolacak bunun için Enter,Stay,Exit triggerlarını çağırdım ki kesin sonuç elde edebileyim.
    //Merminin hızı çok olunca nesnenin içinden geçip gidebiliyor bunu engellemek için 3metod da kullanıldı.
    //Enemy tagine sahip nesnelerde yok olması için enemyHealt classı kullanıldı.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {

            myPC.removeForce();
            Destroy(gameObject);

            if (other.tag == "Enemy")
            {
                enemyHealt hurtEnemy = other.gameObject.GetComponent<enemyHealt>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {

            myPC.removeForce();
            Destroy(gameObject);

            if (other.tag == "Enemy")
            {
                enemyHealt hurtEnemy = other.gameObject.GetComponent<enemyHealt>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {

            myPC.removeForce();        
            Destroy(gameObject);

            if (other.tag == "Enemy")
            {
                enemyHealt hurtEnemy = other.gameObject.GetComponent<enemyHealt>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }
}
