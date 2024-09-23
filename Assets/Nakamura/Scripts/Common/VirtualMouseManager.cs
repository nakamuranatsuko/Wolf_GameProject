using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class VirtualMouseManager : MonoBehaviour
{
    // カーソルの親オブジェクト
    [SerializeField] private RectTransform _root;

    // プレイヤーのカーソルPrefab一覧
    [SerializeField] private VirtualMouseInput[] _cursorPrefabs;

    // カーソル移動Action名
    [SerializeField] private string _moveActionName = "Move";

    // カーソル左クリックAction名
    [SerializeField] private string _leftButtonActionName = "LeftButton";

    // 生成されたカーソル一覧
    private readonly List<VirtualMouseInput> _cursors = new();

    // プレイヤーの参加時に呼び出される
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        print($"プレイヤー#{playerInput.playerIndex}が参加しました");

        // インデックスのチェック
        var playerIndex = playerInput.playerIndex;
        if (playerIndex < 0 || playerIndex >= _cursorPrefabs.Length)
        {
            Debug.LogError("参加できるプレイヤー数を超えています");
            return;
        }

        // カーソルの生成
        var cursor = Instantiate(_cursorPrefabs[playerIndex], _root);
        cursor.name = $"Cursor#{playerIndex}";

        // カーソルを管理リストに追加
        _cursors.Add(cursor);

        // InputActionの取得
        var actions = playerInput.actions;

        var moveAction = actions.FindAction(_moveActionName);
        var leftButtonAction = actions.FindAction(_leftButtonActionName);

        // ActionPropertyの設定
        if (moveAction != null)
            cursor.stickAction = new InputActionProperty(moveAction);
        if (leftButtonAction != null)
            cursor.leftButtonAction = new InputActionProperty(leftButtonAction);
    }

    // プレイヤーの離脱時に呼び出される
    public void OnPlayerLeft(PlayerInput playerInput)
    {
        print($"プレイヤー#{playerInput.playerIndex}が離脱しました");

        // カーソルを管理リストから削除
        var playerIndex = playerInput.playerIndex;

        // 生成されたカーソル取得
        var cursor = _cursors.Find(c => c != null && c.name == $"Cursor#{playerIndex}");
        if (cursor == null) return;

        // カーソルの削除
        _cursors.Remove(cursor);
        Destroy(cursor.gameObject);
    }
}