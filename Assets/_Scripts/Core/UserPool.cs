using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Core
{
    public class UserPool: MonoBehaviour
    {
        [SerializeField]
        private GameObject _userPrefab;
        
        public int poolSize = 50;
        private Queue<GameObject> _userPool;
        
        private void Start()
        {
            _userPool = new Queue<GameObject>();
            InstantiatePool();
        }
    
        private void InstantiatePool()
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject user = Instantiate(_userPrefab);
                user.SetActive(false);
                _userPool.Enqueue(user);
            }
        }
        public GameObject GetUserFromPool(Transform transform)
        {
            if (_userPool.Count > 0)
            {
                GameObject user = _userPool.Dequeue();
                user.transform.SetParent(transform, false);
                user.SetActive(true);
                return user;
            }
            else
            {
                InstantiatePool();
                GameObject user = _userPool.Dequeue();
                user.transform.SetParent(transform, false);
                user.SetActive(true);
                return user;
            }
        }
    
        public void ReturnUserToPool(GameObject enemy)
        {
            enemy.SetActive(false);
            _userPool.Enqueue(enemy);
        }

        public void ReturnAllToPool()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            
            foreach (var enemy in enemies)
            {
                enemy.SetActive(false);
            }
        }
    }
}