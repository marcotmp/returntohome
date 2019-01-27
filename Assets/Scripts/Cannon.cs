using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject cannon;
    public Transform target;
    public Transform bulletStart;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        // aim

        // ang = arc * hipotenusa
    }

    public IEnumerator ShootCoroutine()
    {
        yield return null;
        while (gameObject.activeSelf)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        //var instance = Instantiate(bulletPrefab);
    }
}
