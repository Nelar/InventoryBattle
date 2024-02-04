using InventoryBattle.Configs;
using UnityEngine;
using Zenject;

namespace Runner.Installers
{
    //Installer in DI for configuration classes
    [CreateAssetMenu(fileName = "Configs", menuName = "Installers/Configs")]
    public class ConfigsInstaller : ScriptableObjectInstaller<ConfigsInstaller>
    {
        [SerializeField]
        private Inventory _inventory;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Inventory>().FromInstance(_inventory).AsSingle();            
        }
    }
}