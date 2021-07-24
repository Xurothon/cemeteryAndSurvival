using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public Transform startPosition;
    public float timeBetweenBullets = 1f;

    private void CreateBullet()
    {
        Rigidbody bullet = Instantiate(bulletPrefab);
        bullet.transform.position = startPosition.position;
        bullet.velocity = transform.forward * 35;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsInvoking("CreateBullet"))
            {
                InvokeRepeating("CreateBullet", 0f, timeBetweenBullets);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("CreateBullet");
        }
    }
}
