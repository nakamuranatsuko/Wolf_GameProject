using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPositionManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> itemObj;
    [SerializeField]
    public List<Vector2> itemPos;

    private void Awake()
    {
        for(int i = 0;i < itemObj.Count;i++)
        {
            //�ʒu���̐������������_���Ɍ��߂�
            int rnd = Random.Range(0, itemPos.Count);
            //�I�u�W�F�N�g�Ƀ����_���Ɍ��߂��ʒu������
            itemObj[i].transform.position = itemPos[rnd];
            //�g�����ʒu���͍폜
            itemPos.RemoveAt(rnd);
        }
    }
}
