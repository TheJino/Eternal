using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public Transform attackPoint; 
    public GameObject meleeHitboxPrefab; 
    public float attackRate = 2f; 
    private float nextAttackTime = 0f; 

    void Update()
    {
        RotateAttackPointToMouse();

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                MeleeAttack();
                nextAttackTime = Time.time + 1f / attackRate; 
            }
        }
    }

    void RotateAttackPointToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; 

        Vector3 direction = (mousePosition - transform.position).normalized;
        float radius = 1.0f; 
        attackPoint.position = transform.position + direction * radius;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        attackPoint.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void MeleeAttack()
    {
        GameObject hitbox = Instantiate(meleeHitboxPrefab, attackPoint.position, attackPoint.rotation);
        Destroy(hitbox, 0.5f); 
    }
}
