using UnityEngine;

/// <summary>
/// Source of gravity for GravityBody
/// </summary>
public class GravitySource : MonoBehaviour
{
    #region Inspector Variables

    [SerializeField]
    public float _Force = -10;

    [SerializeField]
    public float _Mass = 50;

    #endregion Inspector Variables
    

    #region Public Methods
    
    /// <summary>
    /// Called internally in FixedUpdate by GravityBody
    /// </summary>
    public void Affect(GravityBody gravityBody)
    {
        Vector3 gravityUp = (gravityBody.transform.position - transform.position).normalized;
        Vector3 bodyUp = gravityBody.transform.up;
        
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * gravityBody.transform.rotation;
        gravityBody.transform.rotation = Quaternion.Slerp(gravityBody.transform.rotation, targetRotation, 50 * Time.deltaTime);

        if (gravityBody.Ground)
        {
            gravityUp = gravityBody.Ground.transform.up;
        }

        gravityBody.Rigidbody.AddForce(gravityUp * _Force * _Mass * gravityBody.Mass);
    }

    #endregion Public Methods
}