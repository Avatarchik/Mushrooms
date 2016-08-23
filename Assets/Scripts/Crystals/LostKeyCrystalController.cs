using UnityEngine;
using System.Collections;

public class LostKeyCrystalController : MonoBehaviour {

    [SerializeField]
    private QuestController _QuestController;

    void OnTriggerEnter(Collider other)
    {
        _QuestController.CollectLostKeyCrystal();
        Destroy(gameObject);
    }
}
