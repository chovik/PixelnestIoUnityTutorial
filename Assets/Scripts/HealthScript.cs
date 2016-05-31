using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{
    public int hp = 1;

    public bool isEnemy = false;

    public void Damage(int damage)
    {
        if(damage < 0)
        {
            return;
        }
        
        hp -= damage;

        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();

        if(shot != null)
        {
            if(shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);
                Destroy(shot.gameObject);
            }            
        }
    }
}
