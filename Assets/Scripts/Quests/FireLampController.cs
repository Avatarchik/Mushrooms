using UnityEngine;
using System.Collections;

public class FireLampController : MonoBehaviour {

    [SerializeField]
    private GameObject _LampFire;
    
    public void SetFiredUp(bool firedUp)
    {
        _LampFire.SetActive(firedUp);
    }
}
