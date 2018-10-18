using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpring : MonoBehaviour {

    public GameObject[] bones;
    public GameObject center;
    public Rigidbody[] bonesRigidbody;

    public PhysicMaterial scmaterial;
    private SphereCollider sc;

    //private float dis;
    private Vector3 offset;
    // Use this for initialization
    void Awake()
    {
        bones = GameObject.FindGameObjectsWithTag("Bones");
        sc = GetComponent<SphereCollider>();
        sc.material = scmaterial;
        SpringJoint sJ;
        for (int i = 0; i < bones.Length - 1; i++)
        {
            sJ = gameObject.AddComponent(typeof(SpringJoint)) as SpringJoint;
            sJ.spring = 100;
            sJ.damper = 0;
            sJ.massScale = 2f;
            sJ.connectedMassScale = 2f;

            if (bones[i] != this.gameObject)
            {
                sJ.connectedBody = bones[i].GetComponent<Rigidbody>();
            }
            else
            {
                sJ.connectedBody = bones[bones.Length - 1].GetComponent<Rigidbody>();

            }

        }

        offset = this.transform.position - center.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += ((center.transform.position - transform.position) + offset) / 10;
    }
}
