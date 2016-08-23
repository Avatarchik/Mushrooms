using UnityEngine;
using System.Collections;

public class TeleportCrystalController : MonoBehaviour {

    [SerializeField]
    private QuestController _QuestController;

    void OnTriggerEnter(Collider other)
    {
        _QuestController.CollectTeleportCrystal();
        Destroy(gameObject);
    }
}
