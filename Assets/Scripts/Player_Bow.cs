using UnityEngine;

public class Player_Bow : MonoBehaviour
{
    public bool hasBow = false; // Começa falso até coletar
    public GameObject arrowPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;
    public float detectionRadius = 10f;
    public LayerMask enemyLayer;

    private float nextFireTime;

    void Update()
    {
        // Botão Direito do Mouse (1) e verificação de posse
        if (hasBow && Input.GetMouseButtonDown(1) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject arrowObj = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Homing_Arrow arrowScript = arrowObj.GetComponent<Homing_Arrow>();

        arrowScript.SetTarget(FindNearestEnemy());
    }

    Transform FindNearestEnemy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, detectionRadius, enemyLayer);
        Transform closest = null;
        float minDistance = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                closest = enemy.transform;
            }
        }
        return closest;
    }
}