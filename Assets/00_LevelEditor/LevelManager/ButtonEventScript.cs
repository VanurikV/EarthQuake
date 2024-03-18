using System.Linq;
using UnityEngine;

public partial class LevelManagerScript
{
    public void OnPrevButton()
    {
        if (CurLevel == 0) return;
        SaveCurMap();
        CurLevel--;
        RestartLevel();
    }

    public void OnNextButton()
    {
        if (CurLevel == Const.MaxLevel - 1) return;
        SaveCurMap();
        CurLevel++;
        RestartLevel();
    }
    
    public void OnLoadButton()
    {
        LoadCurMap();
        RestartLevel();
    }

    public void OnSaveButton()
    {
        SaveCurMap();
    }
    
    
    public void OnObjectButton(GameObject o)
    {
        GameObject parent= o.GetComponentsInChildren<Transform>().Last().gameObject;
        int id = int.Parse(parent.name.Substring(0, 4));
        CursorScript.ChangeCursor(AllPrefab[id], id);
        
    }
    
}