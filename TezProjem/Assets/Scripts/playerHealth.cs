using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {
    //restartGame class
    public restartGame theGameManager;

    public float playerFullHealth;

    public GameObject deathFX;
    float currentHealth;
    Player controlMovement;
    //HUD Variables
    public Slider healthSlider;
    public Image damageScreen;
    public Text gameOverTextScreen;
    public Text winTextScreen;

    bool damaged = false;
    Color damagedColor = new Color(0f, 0f, 0f, 0.5f);
    float smoothColor = 5f;   
    //Audio 
    public AudioClip playerDeath;
    public AudioClip playerHurt;
    AudioSource playerAS;
    void Start () {
        currentHealth = playerFullHealth;
        controlMovement = GetComponent<Player>();
        //HUD
        healthSlider.maxValue = playerFullHealth;
        healthSlider.value = playerFullHealth;
        damaged = false;
	}
	
	
	void Update () {
        if (damaged)
        {
            damageScreen.color = damagedColor;
        }else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor * Time.deltaTime);
        }
        damaged = false;
        playerAS = GetComponent<AudioSource>();
    }
    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;
        playerAS.clip = playerHurt;
        playerAS.Play();
        playerAS.volume = 0.2f;
     

        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            makeDead();
        }
    }
    public void addHealth(float health)
    {
        currentHealth += health;
        if (currentHealth > playerFullHealth) currentHealth = playerFullHealth;
        healthSlider.value = currentHealth;
    }
    public void makeDead()
    {
        healthSlider.value = 0f;
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(playerDeath, transform.position);
        damageScreen.color = damagedColor;
        Animator gameOverAnimator = gameOverTextScreen.GetComponent<Animator>();
        gameOverAnimator.SetTrigger("gameOver");
        theGameManager.restartTheGame();
    }
    public void winGame()
    {
        Destroy(gameObject);
        theGameManager.restartTheGame();
        Animator winGameAnim = winTextScreen.GetComponent<Animator>();
        winGameAnim.SetTrigger("gameOver");
    }
}

