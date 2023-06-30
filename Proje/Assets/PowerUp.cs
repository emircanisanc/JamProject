using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour, ICollectable
{
    [SerializeField] AudioClip collectClip;

    public virtual void Collect()
    {
        if (collectClip)
            AudioSource.PlayClipAtPoint(collectClip, transform.position);
        Destroy(gameObject);
    }
}
