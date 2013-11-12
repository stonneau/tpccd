using UnityEngine;
using System.Collections;

public class CCD3d : MonoBehaviour {
	#region script_parameters	
	// the target we want the end-effector to reach
	// In our case the cube
	public Transform target;	
	#endregion script_parameters
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// in each frame we make one iteration
		CCDStep3D(gameObject.transform.parent, gameObject.transform, target);
	}
	
	/// \brief method for computing an angle value between two 3d vectors using
	/// their dot product.
	/// \return the value of the angle existing between a and b.
	private float ComputeAngle3D(Vector3 a, Vector3 b)
	{
        float theta = 0;
		// TODO
		return theta;
	}
	
	/// \brief performs one step of the CCD algorithm in 3d. For each joint in the kinematic chain,
	/// we compute the angle theta = (effector.joint.target). We then compute the axis
	/// u =  [target-joint] ^ [effector-joint] and apply the rotation theta around this axis to drive 
	/// the effector towards the target.The method is recursive
	/// and calls itself by going up the joint hierarchy.
	/// \param joint the current joint that will be rotated towards the target.
	/// \param effector the end effector transform.
	/// \param target the transform containing the position we want the end-effector to reach.
	private void CCDStep3D(Transform joint, Transform effector, Transform target)
	{
		// TODO
		if(joint.parent != null)
			
		{
			CCDStep3D(joint.parent, effector, target);
		}
	}
}
