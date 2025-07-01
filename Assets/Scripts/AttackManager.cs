using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class AttackManager : MonoBehaviour
{
    public Animator animator;
    public GameObject muzzleFlashPrefab;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public void shoot()
    {
        StartCoroutine(ShootWithDelay());
    }

    private IEnumerator ShootWithDelay()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject flash = Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation);
        Destroy(flash, 0.1f);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
