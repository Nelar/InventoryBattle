using InventoryBattle.UI;
using UnityEngine;
using Zenject;

namespace InventoryBattle.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField]
        UIInventory _inventory;
        [SerializeField]
        UIItemWindow _itemWindow;
        [SerializeField]
        UIInGameWindow _inGameWindow;
        [SerializeField]
        UILoseWindow _loseWindow;
        [SerializeField]
        UIWinWindow _winWindow;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UIInventory>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIItemWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIInGameWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<UILoseWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIWinWindow>().AsSingle();
        }
    }
}

