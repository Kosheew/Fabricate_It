using UnityEngine;

namespace Managers
{
    public class BuildingVisualManager
    {
        private readonly MeshFilter _meshBuild;
        private readonly MeshRenderer _materialBuild;
        private readonly MeshRenderer _materialGex;
        private readonly BuildSettings _buildSettings;

        public BuildingVisualManager(MeshFilter meshBuild, MeshRenderer materialBuild, MeshRenderer materialGex, BuildSettings buildSettings)
        {
            _meshBuild = meshBuild;
            _materialBuild = materialBuild;
            _materialGex = materialGex;
            _buildSettings = buildSettings;
        }


        public void ApplyConstructionVisuals()
        {
            _meshBuild.mesh = _buildSettings.MeshBuilding;
            _materialBuild.material = _buildSettings.BuildingMaterial;
            _materialGex.material = _buildSettings.GexMaterial;
        }  
    }
}
