using System;
using System.Collections.Generic;

[Serializable] // Атрибут дозволяє серіалізувати клас
public class GameData
{
    public SerializableVector3 Pos;
    public List<Quest> Quests;  // Список квестів, які має гравець
    public int Gold;            // Кількість золота у гравця
    public string Name;         // Ім'я гравця

}

[Serializable] // Атрибут дозволяє серіалізувати клас
public class Quest
{
    public string Name;      // Назва квесту
    public float Progress;   // Прогрес квесту (можливо, у відсотках або іншій формі)
}
