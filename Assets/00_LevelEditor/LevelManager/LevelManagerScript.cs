using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public partial class LevelManagerScript : MonoBehaviour
{
    [SerializeField] private CurLevelScript _curLevel;
    public TMP_Text CurLevelText;

    [Space(20)] public MapLevel CurMap;

    [Space(20)] public CursorScript CursorScript;

    [Space(20)] public Dictionary<int, GameObject> AllPrefab;


    public MouseControls EditorControl;

    public GameObject BkgroundContainer;
    public GameObject GroundContainer;
    public GameObject StoneBlockContainer;

    private GameObject o;

    public int CurLevel
    {
        get { return _curLevel.level; }
        set
        {
            _curLevel.level = value;
            CurLevelText.text = CurLevel.ToString("D2");
        }
    }

    void Start()
    {
        LoadAllPrefabs();
        RestartLevel();
    }

    public void RestartLevel()
    {
        CurLevelText.text = CurLevel.ToString("D2");

        ResetLevel();
        LoadCurMap();
        DrawGround();
    }


    public void PasteBlock(int posX, int posY, int BlockId)
    {
        Debug.Log("Paste Blck" + posX + " " + posY + " " + BlockId);

        CurMap.Grid[posX, posY].GameObjectId = BlockId;

        CurMap.Grid[posX, posY].Type = MapLevel.GetType(BlockId);

        o = Instantiate(AllPrefab[BlockId], GroundContainer.transform);
        o.name = posX.ToString("D2") + "_" + posY.ToString("D2") + "_" + o.name;
        o.transform.localPosition = new Vector3(posX * 64, -posY * 64);
    }

    


    private void DrawGround()
    {
        for (int y = 0; y < Const.LevelDy; y++)
        {
            for (int x = 0; x < Const.LevelDx; x++)
            {
                if (CurMap.Grid[x, y].GameObjectId == 0) continue;


                switch (CurMap.Grid[x, y].GameObjectId)
                {
                    case 0501:
                    case 0502:
                        o = Instantiate(AllPrefab[CurMap.Grid[x, y].GameObjectId], StoneBlockContainer.transform);
                        break;
                    default:
                        o = Instantiate(AllPrefab[CurMap.Grid[x, y].GameObjectId], GroundContainer.transform);
                        break;
                }


                //GameObject o = Instantiate(AllPrefab[CurMap.GroundLayer[x, y]], GroundContainer.transform);
                o.name = x.ToString("D2") + "_" + y.ToString("D2") + "_" + o.name;
                o.transform.localPosition = new Vector3(x * 64, -y * 64);
            }
        }
    }


    private void Awake() => EditorControl = new MouseControls();
    private void OnEnable() => EditorControl.Enable();
    private void OnDisable() => EditorControl.Disable();
}