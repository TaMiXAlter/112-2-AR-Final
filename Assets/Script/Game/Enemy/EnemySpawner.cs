using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ETouch = UnityEngine.InputSystem.EnhancedTouch.Touch;
public class EnemySpawner : MonoBehaviour,IDamageable
{
    [SerializeField]
    private GameObject enemyPerfeb;
    
    [SerializeField]
    private float spwnerInterval = 3f;

    [SerializeField]
    private int HP=1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spwnerInterval, enemyPerfeb));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        GameObject newEnemy = Instantiate(enemy, transform.position, transform.rotation);
        yield return new WaitForSeconds(interval);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

    public void TakeDamage(int damage)
    {
        HP-=damage;
        if (HP == 0)
        {
            Destroy(gameObject);
        }
    }
}
