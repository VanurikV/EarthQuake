using UnityEngine;

public partial class LevelManagerScript
{
    private void ResetLevel()
    {
        ClearBkgContainer();

        CurMap = new MapLevel();
    }

    private void ClearBkgContainer()
    {
        foreach (Transform child in BkgroundContainer.GetComponentsInChildren(typeof(Transform), true))
        {
            if (child == BkgroundContainer.transform) continue;
            GameObject.Destroy(child.gameObject);
        }
    }
}