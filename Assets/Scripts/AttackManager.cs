using System;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class AttackManager : MonoBehaviour
{
    public Animator animator;
    public GameObject muzzleFlashPrefab;
    public Transform firePoint;
    public GameObject bulletPrefab;

    void shoot()
    {
        GameObject flash = Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation);
        Destroy(flash, 0.05f);
    }
}
