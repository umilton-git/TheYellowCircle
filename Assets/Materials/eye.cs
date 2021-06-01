// --------------------------------------------------------------------------------------
//      -  Anmar Al-Sharif - ~AnmarCG~ - shark0259@gmail.com 
// --------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class eye : MonoBehaviour {

    public Material mat;
    public Transform dirObject;

    // Tweaks
    [Range(0,2)]
    public float depth = 1.441f;
    [Range(0,2)]
    public float radius = 0.143f;
    [Range(0,2)]
    public float IOR = 0.538f;

    Vector3 frontNormal;

	void Update () {


        mat.SetFloat("_anteriorChamberDepth", depth);
        mat.SetFloat("_radius", radius);
        mat.SetFloat("_IOR", IOR);

        frontNormal = (this.transform.position - dirObject.position).normalized;
        mat.SetVector("_frontNormalW", frontNormal);
        transform.LookAt(dirObject.position);
	}

    void OnApplicationQuit(){
        frontNormal = new Vector3(0, 0, -1);
        mat.SetVector("_frontNormalW", frontNormal);
    }
}
