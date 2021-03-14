using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{

    [Header("Amount Enemy ")]
    public List<GameObject> _spawnPool;
    [Header("Border for enemy spawn")]
    [SerializeField] private GameObject _quad; // border for spawn

    //---------------------------------------------------------------------------------------------
    private void Start()
    {
        SpawnObjects();
    }

    //---------------------------------------------------------------------------------------------

    public void SpawnObjects()
    {
        GameObject prefab;
        MeshCollider border = _quad.GetComponent<MeshCollider>();
        float screenX;
        Vector2 pos;

        for (int i = 0; i < _spawnPool.Count; i++)   
        {
            prefab = _spawnPool[i];
            screenX = Random.Range(border.bounds.min.x + 2, border.bounds.max.x - 2);
            pos = new Vector2(screenX, transform.position.y);

            if (_spawnPool.Count <= 8)
            {
                // check is here there is enemy
                if (Physics2D.OverlapCircle(pos, 1.0f) != null)
                {
                    i--;
                    continue;
                }

                else
                {
                    Instantiate(prefab, pos, prefab.transform.rotation);
                }
            }
            // if crossing enemy
            else
            {
                Instantiate(prefab, pos, prefab.transform.rotation);
            }

        }  
    }

    //---------------------------------------------------------------------------------------------

    public void DestroyObjects()
    {
        foreach (var obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(obj);
        }
    }

    //---------------------------------------------------------------------------------------------
}
