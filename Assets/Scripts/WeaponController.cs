using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject prefabBullet;

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            var firePoint = GetComponent<Transform>().position;
            if (firePoint != null)
                Instantiate(prefabBullet, new Vector3(firePoint.x, firePoint.y, 0), Quaternion.identity);
        }
    }
}
