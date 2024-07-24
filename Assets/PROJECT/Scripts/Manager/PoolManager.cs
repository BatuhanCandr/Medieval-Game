using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace StolenPadCase
{
    public enum ObjectType
    {
        skeleton,
        evilMage,
        arrow,
        fireBall,
        AISoldier,
        coin,
        novaBlast,
        deathFX,
    }

    public class PoolManager : MonoBehaviour
    {
        public ObjectType _objectType;

        [Serializable]
     
        public class Pool
        {
            public List<GameObject> pooledObjects;
            public GameObject objectPrefab;
            public int poolSize;
            public int spawnedObjects;
        }
        [SerializeField] private Pool[] pools = null;

        private void Awake()
        {
            for (int j = 0; j < pools.Length; j++)
            {
                pools[j].pooledObjects = new();

                for (int i = 0; i < pools[j].poolSize; i++)
                {
                    GameObject obj = Instantiate(pools[j].objectPrefab, transform, true);
                    obj.SetActive(false);

                    pools[j].pooledObjects.Add(obj);
                }
            }
        }

        public GameObject GetPooledObject(ObjectType objectType)
        {
            int objectTypeIndex = (int)objectType;
            if (objectTypeIndex >= pools.Length) return null;


            var pool = pools[objectTypeIndex];
            if (pool.spawnedObjects > pool.pooledObjects.Count) return null;

            GameObject obj = pool.pooledObjects[pool.spawnedObjects];
            pool.spawnedObjects++;

            obj.SetActive(true);


            return obj;
        }


        public void SetPooledObject(GameObject obj, int objectType)
        {
            if (objectType >= pools.Length)
            {
                Debug.LogWarning("Invalid object type!");
            }


            obj.transform.SetParent(transform);
            obj.SetActive(false);
           
        }
    }
}