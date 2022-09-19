using UnityEngine;
using UnityEngine.Pool;

namespace KID
{
    /// <summary>
    /// 物件池管理器
    /// </summary>
    public class ObjectPoolManager : MonoBehaviour
    {
        [SerializeField, Header("要生成的物件")]
        private GameObject prefabSphere;
        [SerializeField]
        ObjectPool<GameObject> objectPool;

        private void Awake()
        {
            objectPool = new ObjectPool<GameObject>(() =>
            {
                return Instantiate(prefabSphere);
            }, sphere =>
            {
                sphere.SetActive(true);
            }, sphere =>
            {
                sphere.SetActive(false);
            }, sphere =>
            {
                Destroy(sphere);
            }, false, 10, 20);

            InvokeRepeating("SpawnSphere", 0, 0.1f);
        }

        /// <summary>
        /// 生成球體
        /// </summary>
        private void SpawnSphere()
        {
            GameObject tempSphere = objectPool.Get();
            Vector3 pos;
            pos.x = Random.Range(0, 5f);
            pos.z = Random.Range(0, 5f);
            pos.y = Random.Range(5f, 7f);
            tempSphere.transform.position = pos;

            tempSphere.GetComponent<SphereHit>().Init(SphereHit);
        }

        private void SphereHit(GameObject sphere)
        {
            objectPool.Release(sphere);
        }
    }
}
