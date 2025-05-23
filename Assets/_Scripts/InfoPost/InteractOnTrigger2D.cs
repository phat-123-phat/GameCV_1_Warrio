using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class InteractOnTrigger2D : MonoBehaviour
{
    public LayerMask layers;
    public UnityEvent OnEnter, OnExit; 

    protected Collider2D m_Collider;

    void Reset()
    {
        layers = LayerMask.NameToLayer("Everything");
        m_Collider = GetComponent<Collider2D>();
        m_Collider.isTrigger = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        
        if (layers.Contains(other.gameObject))
        {
            ExecuteOnEnter(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        

        if (layers.Contains(other.gameObject))
        {
            ExecuteOnExit(other);
        }
    }

    protected virtual void ExecuteOnEnter(Collider2D other)
    {
        OnEnter.Invoke();
    }

    protected virtual void ExecuteOnExit(Collider2D other)
    {
        OnExit.Invoke();
    }
}

