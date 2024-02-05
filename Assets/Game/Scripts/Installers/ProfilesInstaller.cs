using Zenject;

namespace InventoryBattle.Installers
{
    public class ProfilesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerProfile>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyProfile>().AsSingle();
        }
    }
}
