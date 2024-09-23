using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class VirtualMouseManager : MonoBehaviour
{
    // �J�[�\���̐e�I�u�W�F�N�g
    [SerializeField] private RectTransform _root;

    // �v���C���[�̃J�[�\��Prefab�ꗗ
    [SerializeField] private VirtualMouseInput[] _cursorPrefabs;

    // �J�[�\���ړ�Action��
    [SerializeField] private string _moveActionName = "Move";

    // �J�[�\�����N���b�NAction��
    [SerializeField] private string _leftButtonActionName = "LeftButton";

    // �������ꂽ�J�[�\���ꗗ
    private readonly List<VirtualMouseInput> _cursors = new();

    // �v���C���[�̎Q�����ɌĂяo�����
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        print($"�v���C���[#{playerInput.playerIndex}���Q�����܂���");

        // �C���f�b�N�X�̃`�F�b�N
        var playerIndex = playerInput.playerIndex;
        if (playerIndex < 0 || playerIndex >= _cursorPrefabs.Length)
        {
            Debug.LogError("�Q���ł���v���C���[���𒴂��Ă��܂�");
            return;
        }

        // �J�[�\���̐���
        var cursor = Instantiate(_cursorPrefabs[playerIndex], _root);
        cursor.name = $"Cursor#{playerIndex}";

        // �J�[�\�����Ǘ����X�g�ɒǉ�
        _cursors.Add(cursor);

        // InputAction�̎擾
        var actions = playerInput.actions;

        var moveAction = actions.FindAction(_moveActionName);
        var leftButtonAction = actions.FindAction(_leftButtonActionName);

        // ActionProperty�̐ݒ�
        if (moveAction != null)
            cursor.stickAction = new InputActionProperty(moveAction);
        if (leftButtonAction != null)
            cursor.leftButtonAction = new InputActionProperty(leftButtonAction);
    }

    // �v���C���[�̗��E���ɌĂяo�����
    public void OnPlayerLeft(PlayerInput playerInput)
    {
        print($"�v���C���[#{playerInput.playerIndex}�����E���܂���");

        // �J�[�\�����Ǘ����X�g����폜
        var playerIndex = playerInput.playerIndex;

        // �������ꂽ�J�[�\���擾
        var cursor = _cursors.Find(c => c != null && c.name == $"Cursor#{playerIndex}");
        if (cursor == null) return;

        // �J�[�\���̍폜
        _cursors.Remove(cursor);
        Destroy(cursor.gameObject);
    }
}