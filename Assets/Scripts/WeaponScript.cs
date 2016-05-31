using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

    public Transform shotPrefab;

    public float shootingRate = 0.25f;

    private float shootCooldown = 0f;

    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }


    // Use this for initialization
    void Start ()
    {
        shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(shootCooldown > 0f)
        {
            shootCooldown -= Time.deltaTime;
        }
	}

    public void Attack(bool isEnemy)
    {
        if(CanAttack)
        {
            shootCooldown = shootingRate;

            Transform shotTransform = Instantiate(shotPrefab) as Transform;
            shotTransform.position = transform.position;

            var shot = shotTransform.gameObject.GetComponent<ShotScript>();

            if(shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            var move = shotTransform.gameObject.GetComponent<MoveScript>();

            if(move != null)
            {
                move.direction = transform.right;
            }
        }
    }
}
