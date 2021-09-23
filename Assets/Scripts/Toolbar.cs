using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Toolbar : MonoBehaviour
{
    World world;            // создаём ссыку на объект World
    public Player player;   // создаём ссыку на объект Player 

    public RectTransform highlight; // создаём ссыку координаты объекта highlight
    public ItemSlot[] itemSlots;    // создаём массив слотов

    int slotIndex = 0; //

    private void Start()
    {
        // находим на сцене объект World, получаем доступ к скрипту world
        world = GameObject.Find("World").GetComponent<World>();

        //for(int i = 0; i < 6; i++)
        // пробегаемся по всем элементам массива itemSlots
        foreach (ItemSlot slot in itemSlots) 
        {
            // в скрипте world находим элементы, находим иконки элементов, устанавливаем иконку в слот
            slot.icon.sprite = world.blocktypes[slot.itemID].icon;
            // активируем картинку слота
            slot.icon.enabled = true;
        }
        // выбираем первый элемент из массива
        player.selectedBlockIndex = itemSlots[slotIndex].itemID;
    }

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if(scroll != 0)// если вращаем колесо мышки 
        {
            if (scroll < 0) // крутим колесо вниз
            {
                slotIndex--;
            }
            else// крутим колесо вверх
                slotIndex++;

            // проверка на переполнение длины массива, 
            if (slotIndex > itemSlots.Length - 1 )
                slotIndex = 0;
            if (slotIndex < 0)
                slotIndex = itemSlots.Length - 1;

            // передвижение рамки(highLight)
            highlight.position = itemSlots[slotIndex].icon.transform.position;
            // выбираем элемент из массива
            player.selectedBlockIndex = itemSlots[slotIndex].itemID;
        }
    }
}

[System.Serializable]
public class ItemSlot // создаём класс ItemSlot
{
    public byte itemID;
    public Image icon;
}