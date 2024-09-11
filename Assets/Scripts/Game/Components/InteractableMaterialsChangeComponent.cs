using UnityEngine;

namespace Game.Components
{
    public class InteractableMaterialsChangeComponent : MonoBehaviour
    {
        [SerializeField] private Material normalMaterial;
        [SerializeField] private Material interactableMaterial;
        [SerializeField] private MeshRenderer[] meshRenderers;

        public void SetNormalMaterial()
        {
            foreach (var meshRenderer in meshRenderers)
                meshRenderer.material = normalMaterial;
        }

        public void SetInteractableMaterial()
        {
            foreach (var meshRenderer in meshRenderers)
                meshRenderer.material = interactableMaterial;
        }
    }
}