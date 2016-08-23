using UnityEngine;
using System.Collections;

public class FlyingPlatformsCrystalController : MonoBehaviour {

    [SerializeField]
    private QuestController _QuestController;

    void OnTriggerEnter(Collider other)
    {
        _QuestController.CollectFlyingPlatformsCrystal();
        Destroy(gameObject);
    }
}
