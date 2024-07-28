using UnityEngine;
public interface ICustomPool
{
   public void SetPool<T>(CustomPool<T> pool) where T : Component;
}
