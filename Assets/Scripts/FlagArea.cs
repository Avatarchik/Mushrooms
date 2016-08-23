using UnityEngine;
using System.Collections;

/// <summary>
/// Objects with this script act as a area for placing flags
/// </summary>
public class FlagArea : MonoBehaviour
{
    #region Private Variables
    private GameObject _Flag = null;
    #endregion Private Variables

    #region Unity Messages
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer != LayerMask.NameToLayer("Flag"))
            return;

        SetFlag(other.gameObject);
    }

    void Update()
    {

    }
    #endregion Unity Messages

    #region Private Methods
    private void SetFlag(GameObject flag)
    {
        if(_Flag != null)
        {
            Destroy(_Flag);
        }
        _Flag = flag;
    }
    #endregion Private Methods
}