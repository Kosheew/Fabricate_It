using System;
using System.Collections.Generic;

[Serializable] // ������� �������� ����������� ����
public class GameData
{
    public SerializableVector3 Pos;
    public List<Quest> Quests;  // ������ ������, �� �� �������
    public int Gold;            // ʳ������ ������ � ������
    public string Name;         // ��'� ������

}

[Serializable] // ������� �������� ����������� ����
public class Quest
{
    public string Name;      // ����� ������
    public float Progress;   // ������� ������ (�������, � �������� ��� ����� ����)
}
