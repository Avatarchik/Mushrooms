using UnityEngine;
using System.Collections;

public class GodraysCrystalController : MonoBehaviour {

    [SerializeField]
    private QuestController _QuestController;

    void OnTriggerEnter(Collider other)
    {
        _QuestController.CollectGodraysCrystal();
        Destroy(gameObject);
    }
}
