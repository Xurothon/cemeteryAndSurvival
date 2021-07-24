using UnityEngine;

public class EnemyMaterial : MonoBehaviour
{
    public Texture[] materials;

    void Awake()
    {
        Material myMaterial = GetComponent<Renderer>().material;
        myMaterial.mainTexture = materials[Random.Range(0, materials.Length)];
    }
}
