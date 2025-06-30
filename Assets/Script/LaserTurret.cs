using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    public GameObject laserBulletPrefab;
    public Transform player;
    public float shootInterval = 2f;

    private float shootTimer;

    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void Shoot()
    {
        if (player == null) return;

        Vector2 shootDir = player.position - transform.position;
        GameObject bullet = Instantiate(laserBulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<LaserBullet>().SetDirection(shootDir);
    }
}
