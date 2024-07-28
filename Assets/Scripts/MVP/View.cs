using UnityEngine;

public abstract class View : MonoBehaviour
{
    protected Presenter _presenter;
    public void Init(Presenter presenter)
    {
        _presenter = presenter; 
    }

    public abstract void SetHealth(int value);
    
    public abstract void UpdateHealth(int value);

}

