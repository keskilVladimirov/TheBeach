using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.Count; i++)
            {
                var obj = new GameObject();
                var image = obj.AddComponent<Image>(); 
                image.sprite = pool.Sprites[i]; 
                image.SetNativeSize();
                obj.GetComponent<RectTransform>().SetParent(transform);
                obj.SetActive(false);
                obj.name = pool.Sprites[i].name;
                objectPool.Enqueue(obj);
            }
            
            poolDictionary.Add(pool.Name, objectPool);
        }
    }

    public void SpawnFromPool(string namePool, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(namePool))
            return;
        
        var obj = poolDictionary[namePool].Dequeue();
        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        poolDictionary[namePool].Enqueue(obj);
    }
}
