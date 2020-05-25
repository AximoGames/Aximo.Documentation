using Aximo;
using Aximo.Engine;
using Aximo.Engine.Components.Geometry;
using Aximo.Engine.Components.Lights;
using OpenToolkit.Mathematics;

internal class Program
{
    public static void Main(string[] args)
    {
        new MyApplication().Start();
    }
}

public class MyApplication : Application
{
    protected override void SetupScene()
    {
        // it's not required, but we should have a least one light.
        SceneContext.AddActor(new Actor(new PointLightComponent()
        {
            Name = "StaticLight",
            RelativeTranslation = new Vector3(2f, -2.5f, 3.25f),
        }));

        #region construct
        var sphere = Mesh.CreateSphere();

        var cylinder1 = Mesh.CreateCylinder(slices: 16);
        cylinder1.Scale(0.3f, 0.3f);
        cylinder1.Translate(new Vector3(0, 0, 0.05f));
        sphere.AddMesh(cylinder1, 0, 1);

        var cylinder2 = Mesh.CreateCylinder();
        cylinder2.Scale(0.05f, 0.05f);
        cylinder2.Translate(new Vector3(0, 0, 0.3f));
        sphere.AddMesh(cylinder2, 0, 2);
        #endregion

        var comp = new StaticMeshComponent(sphere)
        {
            Name = "Bomb",
            RelativeTranslation = new Vector3(0, 0, 0.55f),
            RelativeScale = new Vector3(2),
            RelativeRotation = new Vector3(0.15f, 0.15f, 0f).ToQuaternion(),
        };

        #region materials
        comp.AddMaterial(new Material
        {
            Color = new Vector4(0.2f, 0.2f, 0.2f, 1),
            Ambient = 0.5f,
            Shininess = 64.0f,
            SpecularStrength = 1f,
        });

        comp.AddMaterial(new Material
        {
            Color = new Vector4(0.1f, 0.1f, 0.1f, 1),
            Ambient = 0.5f,
            Shininess = 32.0f,
            SpecularStrength = 0.5f,
        });

        comp.AddMaterial(new Material
        {
            Color = new Vector4(0.5f, 1 / 255f * 165 * 0.5f, 0, 1),
            Ambient = 0.5f,
            Shininess = 32.0f,
            SpecularStrength = 0.5f,
        });
        #endregion

        SceneContext.AddActor(new Actor(comp));
    }
}
