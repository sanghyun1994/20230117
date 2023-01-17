using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{


    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.Input.KeyAction -= OnInvenEvent;
        Managers.Input.KeyAction += OnInvenEvent;


        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;

        // GameScene �ε�� cursor�߰�
        gameObject.GetOrAddComponent<CursorController>();

        GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "UnityChan");
        Camera.main.gameObject.GetOrAddComponent<CameraController>().SetPlayer(player);
        Managers.Game.Spawn(Define.WorldObject.Monster, "Knight");

        GameObject go = new GameObject { name = "SpawningPool" };
        SpawningPool pool = go.GetOrAddComponent<SpawningPool>();
        pool.SetKeepMonsterCount(5);

    }

    public override void Clear() // ����� ����� �κ�
    {
        
    }

    public void OnInvenEvent()
    {
        Managers.UI.OnOffInvenUI();
        
        //Managers.UI.CloseInvenUI();
        Managers.UI.CloseAllPopupUI();
    }



}
