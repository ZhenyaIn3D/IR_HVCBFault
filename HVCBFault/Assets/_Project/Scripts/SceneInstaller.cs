using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings() {
        Container.Bind<ScanController>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<StepController>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<MainMenuView>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}
