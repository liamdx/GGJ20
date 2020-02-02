using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IRobotPart : MonoBehaviour
{
    public Dictionary<string, int> m_AffectedParameters;
    public int m_Health;
    public Mesh m_AssociatedMesh;
    public BoxCollider m_Col;
    public bool m_LimbBroken;
    public PlayerManager thisPM;

    public GameObject pickup;

    private Mesh gameplayMesh;
    private MeshRenderer meshRenderer;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private MeshFilter meshFilter;
    private const int numBreakOffMeshes = 3;
    

    private List<GameObject> destructibleMeshes;

    private void Awake()
    {
        m_LimbBroken = false;
        m_Col = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

        if (skinnedMeshRenderer == null)
        {
            meshFilter = GetComponent<MeshFilter>();
            if (m_AssociatedMesh != null)
            {
                m_AssociatedMesh = meshFilter.mesh;
                gameplayMesh = meshFilter.mesh;
            }
            else
            {
                gameplayMesh = m_AssociatedMesh;
            }
        }
        else
        {
            if (m_AssociatedMesh != null)
            {
                m_AssociatedMesh = skinnedMeshRenderer.sharedMesh;
                gameplayMesh = skinnedMeshRenderer.sharedMesh;
            }
            else
            {
                gameplayMesh = skinnedMeshRenderer.sharedMesh;
            }
        }

        destructibleMeshes = new List<GameObject>();

        for(int i = 0; i < numBreakOffMeshes; i++)
        {
            GameObject go = new GameObject();
            go.layer = 10;
            MeshFilter mf = go.AddComponent<MeshFilter>();
            MeshRenderer mr = go.AddComponent<MeshRenderer>();
            mr.enabled = false;
            mf.mesh = m_AssociatedMesh;
            go.AddComponent<SphereCollider>();
            Rigidbody rib = go.AddComponent<Rigidbody>();
            rib.isKinematic = true;
            DestoyN d = go.AddComponent<DestoyN>();
            go.SetActive(false);
            destructibleMeshes.Add(go);
        }
        m_Health = 100;
    }

    public void DoReset()
    {
        m_LimbBroken = false;
        skinnedMeshRenderer.enabled = true;
    }

    private void LateUpdate()
    {
        if (!m_LimbBroken)
        {
            if (m_Health <= 0)
            {
                ProvidePickup();
                m_LimbBroken = true;
            }
        }
    }

    void RemoveLimb()
    {       
        Debug.Log("Found skinned mesh renderer");
        skinnedMeshRenderer.enabled = false;
        m_Col.enabled = false;
        m_Col.isTrigger = true;
        GameObject destructible = destructibleMeshes[0];
        destructible.SetActive(true);
        destructible.transform.position = transform.TransformPoint(transform.position);
        destructible.transform.eulerAngles = transform.eulerAngles;
        destructible.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        MeshRenderer mr = destructible.GetComponent<MeshRenderer>();
        mr.material = skinnedMeshRenderer.material;
        mr.enabled = true;
        Rigidbody rib = destructible.GetComponent<Rigidbody>();
        rib.isKinematic = false;
        rib.AddForce(GenRandomDirection() * 20.0f);
        DestoyN destroyer = destructible.GetComponent<DestoyN>();
        destroyer.Destroy(3.0f);

    }

    void ProvidePickup()
    {
        Vector3 randomPos = GenRandomDirection() * 5;
        randomPos.y = 0.0f;

        Vector3 finalPosition = transform.position + randomPos;
        GameObject go = GameObject.Instantiate(pickup, randomPos, Quaternion.identity);
        Rigidbody rib = go.AddComponent<Rigidbody>();
        rib.AddForce(GenRandomDirection() * 3);

    }

    Vector3 GenRandomDirection()
    {
        Vector3 v = Vector3.zero;
        v.x = Random.Range(0.0f, 1.0f);
        v.y = Random.Range(0.0f, 1.0f);
        v.z = Random.Range(0.0f, 1.0f);
        return v;
    }
}
