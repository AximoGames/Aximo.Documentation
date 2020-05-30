using System;
using Aximo;
using Aximo.Engine;
using Aximo.Engine.Components.Geometry;
using Aximo.Engine.Components.Lights;
using OpenToolkit.Mathematics;
using OpenToolkit.Windowing.Common;

internal class Program
{
    public static void Main(string[] args)
    {
        new MyApplication().Start();
    }
}

public class MyApplication : Application
{
    private CubeComponent Box;

    protected override void SetupScene()
    {
        SceneContext.AddActor(new Actor(new PointLightComponent()
        {
            Name = "StaticLight",
            RelativeTranslation = new Vector3(-2f, -1.5f, 3.25f),
        }));

        SceneContext.AddActor(new Actor(Box = new CubeComponent()
        {
            Name = "Box1",
            RelativeRotation = new Vector3(0, 0, 0.5f).ToQuaternion(),
            RelativeScale = new Vector3(1),
            RelativeTranslation = new Vector3(0, 0, 0.5f),
            Material = new Material
            {
                Color = new Vector4(1, 0, 1, 1),
                CastShadow = true,
            },
        }));

        #region defineTween
            Tween.For(Box)
                .ScaleFunc(ScaleFuncs.Power10EaseInOut)
                .Duration(2).Translate(2,0)
                .Then().Duration(1.5f).Scale(0.1f).Translate(1,-2)
                .Then().Duration(3.5f).Scale(1f).Translate(0,0)
                .Repeat().Start();
        #endregion

        SceneContext.AddActor(new Actor(new QuadComponent()
        {
            Name = "Ground",
            RelativeScale = new Vector3(50),
            Material = new Material
            {
                Color = new Vector4(1, 1, 0, 1),
                CastShadow = true,
            },
        }));
    }
}
