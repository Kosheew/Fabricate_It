using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CustomPool<T> where T : Component
{

    private ObjectPool<T> pool;
    private T prefab;

    private Transform startTransform;
    private HashSet<T> activeObjects;

    public CustomPool(T prefab, Transform startPos, int maxSize)
    {
        startTransform = startPos;
        activeObjects = new HashSet<T>();
        this.prefab = prefab;
        pool = new ObjectPool<T>(
            OnCreateObject,
            OnGet,
            OnRealese,
            OnDestroy,
            maxSize: maxSize
        );        
    }

    private void OnDestroy(T obj) 
    {
        GameObject.Destroy(obj.gameObject);
    }

    private void OnRealese(T obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.position = startTransform.position;
        obj.transform.rotation = startTransform.rotation;
        activeObjects.Remove(obj);
    }
    private void OnGet(T obj)
    {
        obj.gameObject.SetActive(true);
        activeObjects.Add(obj);
    }

    private T OnCreateObject()
    {
        T obj = GameObject.Instantiate(prefab, startTransform.position, Quaternion.identity, startTransform);
        obj.gameObject.SetActive(false);
        var script = obj.GetComponent<ICustomPool>();
        script.SetPool(this);
       return obj;
    }

    public T Get()
    {
        return pool.Get();
    }

    public void Release(T obj)
    {
        pool.Release(obj);
    }

    public int CountInactive => pool.CountInactive;

    public int CountActive => activeObjects.Count;
}
