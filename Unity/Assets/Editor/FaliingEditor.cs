using UnityEditor;

[CustomEditor(typeof(fallingBlcokGenerator))]
public class FallingEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        fallingBlcokGenerator map = target as fallingBlcokGenerator;

        map.GenerateMap();
    }
}
