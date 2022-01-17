using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using LearnOpenTK.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace proyekUAS1
{
    class Window : GameWindow
    {
        Mesh ground = new Mesh();
        Mesh road = new Mesh();
        Mesh castleWall = new Mesh();
        Mesh grass = new Mesh();
        Mesh insideCastle1 = new Mesh();
        Mesh insideCastle2 = new Mesh();
        Mesh roofCastle1 = new Mesh();
        Mesh roofCastle2 = new Mesh();
        Mesh bigPillarLeft = new Mesh();
        Mesh bigPillarRight = new Mesh();
        Mesh mediumPillarLeft = new Mesh();
        Mesh mediumPillarRight = new Mesh();
        Mesh smallPillarLeft = new Mesh();
        Mesh smallPillarRight = new Mesh();
        Mesh bigConeLeft = new Mesh();
        Mesh bigConeRight = new Mesh();
        Mesh mediumConeLeft = new Mesh();
        Mesh mediumConeRight = new Mesh();
        Mesh smallConeLeft = new Mesh();
        Mesh smallConeRight = new Mesh();
        // rumah clara 1
        Mesh badanrumahClara1 = new Mesh();
        Mesh ataprumahClara1 = new Mesh();
        Mesh jendelarumahClara1 = new Mesh();
        Mesh pinturumahClara1 = new Mesh();
        Mesh gagangpinturumah = new Mesh();
        // rumah clara 2
        Mesh badanrumahClara2_1 = new Mesh();
        Mesh badanrumahClara2_2 = new Mesh();
        Mesh ataprumahClara2_1 = new Mesh();
        Mesh ataprumahClara2_2 = new Mesh();
        Mesh jendelarumahClara2 = new Mesh();
        Mesh pinturumahClara2 = new Mesh();
        Mesh garasiPintu1 = new Mesh();
        // rumah jenn 1
        Mesh rumahJenn = new Mesh();
        Mesh atapRumahJenn1 = new Mesh();
        Mesh atapRumahJenn2 = new Mesh();
        Mesh jendelaRumahJenn = new Mesh();
        Mesh pintuRumahJenn = new Mesh();
        // rumah jenn 2
        Mesh rumahJenn2 = new Mesh();
        Mesh atapRumah2 = new Mesh();
        Mesh pintuRumah2 = new Mesh();
        Mesh rumahMini2 = new Mesh();
        Mesh atapRumahMini2 = new Mesh();
        Mesh rumahPinggir2 = new Mesh();
        Mesh atapPinggir2 = new Mesh();
        Mesh pintuPinggir2 = new Mesh();
        // gazebo
        Mesh gazeboAtas = new Mesh();
        Mesh tiang1 = new Mesh();
        Mesh tiang2 = new Mesh();
        Mesh tiang3 = new Mesh();
        Mesh tiang4 = new Mesh();
        Mesh tiang5 = new Mesh();
        Mesh tiang6 = new Mesh();
        Mesh alasGazebo = new Mesh();
        Mesh kayu1 = new Mesh();
        Mesh kayu2 = new Mesh();
        Mesh kayu3 = new Mesh();
        Mesh kayu4 = new Mesh();
        Mesh kayu5 = new Mesh();
        Mesh kayu6 = new Mesh();
        Mesh kayu7 = new Mesh();
        Mesh kayu8 = new Mesh();
        Mesh kayu9 = new Mesh();
        Mesh kayu10 = new Mesh();
        Mesh kayuMini1 = new Mesh();
        Mesh kayuMini2 = new Mesh();
        Mesh kayuMini3 = new Mesh();
        Mesh kayuMini4 = new Mesh();
        Mesh kayuMini5 = new Mesh();
        Mesh kayuMini6 = new Mesh();
        Mesh kayuMini7 = new Mesh();
        Mesh kayuMini8 = new Mesh();
        Mesh kayu34Mini1 = new Mesh();
        Mesh kayu34Mini2 = new Mesh();
        Mesh kayu34Mini3 = new Mesh();
        Mesh kayu34Mini4 = new Mesh();
        Mesh kayu34Mini5 = new Mesh();
        Mesh kayu34Mini6 = new Mesh();
        Mesh kayu34Mini7 = new Mesh();
        Mesh kayu56Mini1 = new Mesh();
        Mesh kayu56Mini2 = new Mesh();
        Mesh kayu56Mini3 = new Mesh();
        Mesh kayu56Mini4 = new Mesh();
        Mesh kayu56Mini5 = new Mesh();
        Mesh kayu56Mini6 = new Mesh();
        Mesh kayu56Mini7 = new Mesh();
        Mesh kayu78Mini1 = new Mesh();
        Mesh kayu78Mini2 = new Mesh();
        Mesh kayu78Mini3 = new Mesh();
        Mesh kayu78Mini4 = new Mesh();
        Mesh kayu78Mini5 = new Mesh();
        Mesh kayu78Mini6 = new Mesh();
        Mesh kayu78Mini7 = new Mesh();
        Mesh kayu78Mini8 = new Mesh();

        //snowman
        Mesh snowmanAtas = new Mesh();
        Mesh snowmanTengah = new Mesh();
        Mesh snowmanBawah = new Mesh();
        Mesh topiSnowman = new Mesh();
        Mesh syalSnowman = new Mesh();
        Mesh leftHand = new Mesh();
        Mesh rightHand = new Mesh();
        Mesh leftEye = new Mesh();
        Mesh rightEye = new Mesh();
        // tree freo
        Mesh tree1 = new Mesh();
        Mesh tree2 = new Mesh();
        Mesh tree3 = new Mesh();

        private Vector3 posObject1 = new Vector3(0.0f, 0.0f, -2.0f); 

        // Camera
        private Camera _camera; 
        private Vector3 _objectPos; 
        private Vector2 _lastMousePosition;
        private bool _firstMove;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
            //GL.Enable(EnableCap.Blend);
            //GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        }

        private Matrix4 generateArbRotationMatrix(Vector3 axis, Vector3 center, float degree)
        {
            var rads = MathHelper.DegreesToRadians(degree);

            var secretFormula = new float[4, 4] {
                { (float)Math.Cos(rads) + (float)Math.Pow(axis.X, 2) * (1 - (float)Math.Cos(rads)), axis.X* axis.Y * (1 - (float)Math.Cos(rads)) - axis.Z * (float)Math.Sin(rads),    axis.X * axis.Z * (1 - (float)Math.Cos(rads)) + axis.Y * (float)Math.Sin(rads),   0 },
                { axis.Y * axis.X * (1 - (float)Math.Cos(rads)) + axis.Z * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Y, 2) * (1 - (float)Math.Cos(rads)), axis.Y * axis.Z * (1 - (float)Math.Cos(rads)) - axis.X * (float)Math.Sin(rads),   0 },
                { axis.Z * axis.X * (1 - (float)Math.Cos(rads)) - axis.Y * (float)Math.Sin(rads),   axis.Z * axis.Y * (1 - (float)Math.Cos(rads)) + axis.X * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Z, 2) * (1 - (float)Math.Cos(rads)), 0 },
                { 0, 0, 0, 1}
            };
            var secretFormulaMatrix = new Matrix4(
                new Vector4(secretFormula[0, 0], secretFormula[0, 1], secretFormula[0, 2], secretFormula[0, 3]),
                new Vector4(secretFormula[1, 0], secretFormula[1, 1], secretFormula[1, 2], secretFormula[1, 3]),
                new Vector4(secretFormula[2, 0], secretFormula[2, 1], secretFormula[2, 2], secretFormula[2, 3]),
                new Vector4(secretFormula[3, 0], secretFormula[3, 1], secretFormula[3, 2], secretFormula[3, 3])
            );

            return secretFormulaMatrix;
        }

        protected override void OnLoad()
        {
            GL.ClearColor(0.44f, 0.556f, 0.729f, 1.0f);
            //GL.Enable(EnableCap.DepthTest);

            ground.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/ground/ground.obj", "C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/ground/snow_color.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/ground/specular.png");

            road.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/road/road.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/road/color.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/road/SpecularMap.png");
            
            castleWall.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/castleWall.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/wallbaru.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/wallbaru_spec.png");

            grass.LoadObjFile("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/grass.obj");
            grass.setupObject((float)Size.X, (float)Size.Y);
            grass.setEBO();

            insideCastle1.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/insideCastle1.obj", "C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/wall3.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/wall3_specular.png");
            insideCastle2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/insideCastle2.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/wall2.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/wall2_specular.png");
            roofCastle1.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/roofCastle1.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/roof.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/roof_specular.png");
            roofCastle2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/roofCastle2.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/roof2.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/roof2_specular.png");
            bigPillarLeft.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/bigPillarLeft.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/stone.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/stone_specular.png");
            bigPillarRight.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/bigPillarRight.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/stone.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/stone_specular.png");
            mediumPillarLeft.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/mediumPillarLeft.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/stone.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/stone_specular.png");
            mediumPillarRight.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/mediumPillarRight.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/stone.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/stone_specular.png");
            smallPillarLeft.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/smallPillarLeft.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/stone.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/stone_specular.png");
            smallPillarRight.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/smallPillarRight.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/stone.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/stone_specular.png");
            //
            bigConeLeft.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/bigConeLeft.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/cone.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/cone_specular.png");
            bigConeRight.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/bigConeRight.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/cone.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/cone_specular.png");

            mediumConeLeft.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/mediumConeLeft.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/cone.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/cone_specular.png");
            mediumConeRight.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/mediumConeRight.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/cone.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/cone_specular.png");

            smallConeLeft.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/smallConeLeft.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/cone.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/cone_specular.png");
            smallConeRight.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/smallConeRight.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/cone.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/istana/cone_specular.png");
            // rumah clara 1 
            badanrumahClara1.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara1/badanrumahSatu.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara1/wall.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara1/wallClaraspec.png");

            ataprumahClara1.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara1/ataprumahSatu.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara1/roofClaratext.jfif","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara1/roofClaraspec.png");

            jendelarumahClara1.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara1/jendelarumahSatu.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara1/marbleText.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara1/marbleSpec.png");

            pinturumahClara1.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara1/pinturumahSatu.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara1/pintuClaratext.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara1/pintuClaraSpec.png");
            // rumah clara 2
            badanrumahClara2_1.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/badanrumahDua_1.obj", "C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/wall2.jpeg", "C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/wall2_spec.png");
            badanrumahClara2_2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/badanrumahDua_2.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/wall2.jpeg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/wall2_spec.png");

            ataprumahClara2_1.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/ataprumahDua_1.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/roofClaraDuatext.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/roofClaraDuaspec.png");
            ataprumahClara2_2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/ataprumahDua_2.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/roofClaraDuatext.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/roofClaraDuaspec.png");

            jendelarumahClara2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/jendelarumahDua.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/marbleText.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/marbleSpec.png");

            pinturumahClara2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/pinturumahDua.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/pintuClaraDuatext.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/pintuClaraDuaSpec.png");

            garasiPintu1.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/garasi.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/garasi.png","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahClara2/garasi_spec.png");
            // rumah jenn 1
            rumahJenn.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn1/rumahJenn.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn1/wall.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn1/wall_spec.png");
            atapRumahJenn1.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn1/atapRumahJenn1.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn1/Roof_basecolor.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn1/Roof_specular.png");
            atapRumahJenn2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn1/atapRumahJenn2.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn1/Roof_basecolor.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn1/Roof_specular.png");
            jendelaRumahJenn.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn1/jendelaRumahJenn.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn1/window.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn1/window_spec.png");
            pintuRumahJenn.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn1/pintuRumahJenn.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn1/door.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn1/door_spec.png");
            // rumah jenn 2
            rumahJenn2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/rumah.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/yellow.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/yellow_spec.png");
            atapRumah2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/atap.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/atap.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/atap_spec.png");
            pintuRumah2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/pintu.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/door.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/door_spec.png");
            rumahMini2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/rumahMini.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/yellow.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/yellow_spec.png");
            atapRumahMini2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/atapMini.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/atap.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/atap_spec.png");
            rumahPinggir2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/rumahPinggir.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/yellow.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/yellow_spec.png");
            atapPinggir2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/atapPinggir.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/atap.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/atap_spec.png");
            pintuPinggir2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/pintuPinggir.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/door.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/rumahJenn2/door_spec.png");
            // gazebo
            gazeboAtas.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/gazeboAtas.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            tiang1.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/tiang1.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            tiang2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/tiang2.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            tiang3.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/tiang3.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            tiang4.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/tiang4.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            tiang5.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/tiang5.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            tiang6.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/tiang6.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            alasGazebo.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/alasGazebo.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu1.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu1.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu2.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayuMini1.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayuMini1.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayuMini2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayuMini2.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayuMini3.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayuMini3.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayuMini4.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayuMini4.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayuMini5.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayuMini5.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayuMini6.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayuMini6.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayuMini7.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayuMini7.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayuMini8.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayuMini8.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu3.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu3.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu4.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu4.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu34Mini1.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu34Mini1.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu34Mini2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu34Mini2.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu34Mini3.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu34Mini3.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu34Mini4.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu34Mini4.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu34Mini5.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu34Mini5.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu34Mini6.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu34Mini6.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu34Mini7.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu34Mini7.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu5.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu5.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu6.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu6.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu56Mini1.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu56Mini1.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu56Mini2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu56Mini2.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu56Mini3.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu56Mini3.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu56Mini4.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu56Mini4.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu56Mini5.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu56Mini5.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu56Mini6.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu56Mini6.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu56Mini7.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu56Mini7.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu7.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu7.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu8.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu8.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu78Mini1.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu78Mini1.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu78Mini2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu78Mini2.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu78Mini3.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu78Mini3.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu78Mini4.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu78Mini4.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu78Mini5.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu78Mini5.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu78Mini6.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu78Mini6.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu78Mini7.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu78Mini7.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            kayu78Mini8.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/kayu78Mini8.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/gazebo/SpecularMap.png");
            // snowman
            snowmanBawah.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/bawah.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/color.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/color_spec.png");
            snowmanTengah.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/tengah.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/color.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/color_spec.png");
            snowmanAtas.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/atas.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/color.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/color_spec.png");
            leftEye.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/leftEye.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/wood_spec.png");
            rightEye.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/rightEye.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/wood_spec.png");
            leftHand.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/leftHand.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/wood_spec.png");
            rightHand.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/rightHand.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/wood.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/wood_spec.png");
            syalSnowman.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/syal.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/fabric.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/fabric_spec.png");
            topiSnowman.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/topi.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/fabric.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/snowman/fabric_spec.png");
            // tree
            tree1.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/tree/tree1.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/tree/tree.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/tree/tree_spec.png");
            tree2.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/tree/tree2.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/tree/tree2.jpg","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/tree/tree2_spec.png");
            tree3.setOBJ("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/tree/tree3.obj","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/tree/tree3.png","C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Resources/tree/tree3_Spec.png");

            // Camera
            //var _cameraPosInit = new Vector3(-0.2f, 0.0f, 0.6f); 
            var _cameraPosInit = new Vector3(-1.6f, 0.1f, 0.34f);
            _camera = new Camera(_cameraPosInit, Size.X / (float)Size.Y); 
            _objectPos = posObject1; 
            CursorGrabbed = true;

            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            ground.renderOBJ(_camera, 1);
            road.renderOBJ(_camera, 1);
            // rumah clara 2
            badanrumahClara2_1.renderOBJ2(_camera, 1);
            badanrumahClara2_2.renderOBJ2(_camera, 1);
            pinturumahClara2.renderOBJ2(_camera, 1);
            jendelarumahClara2.renderOBJ2(_camera, 1);
            ataprumahClara2_1.renderOBJ2(_camera, 1);
            ataprumahClara2_2.renderOBJ2(_camera, 1);
            garasiPintu1.renderOBJ2(_camera, 1);
            // istana 
            insideCastle1.renderOBJ(_camera, 1);
            //castleWall.renderOBJ(_camera, 1);
            bigPillarLeft.renderOBJ(_camera, 1);
            bigPillarRight.renderOBJ(_camera, 1);
            roofCastle2.renderOBJ(_camera, 1);
            roofCastle1.renderOBJ(_camera, 1);
            insideCastle2.renderOBJ(_camera, 1);
            castleWall.renderOBJ(_camera, 1);
            mediumPillarLeft.renderOBJ(_camera, 1);
            mediumPillarRight.renderOBJ(_camera, 1);
            smallPillarLeft.renderOBJ(_camera, 1);
            smallPillarRight.renderOBJ(_camera, 1);
            bigConeLeft.renderOBJ(_camera, 1);
            bigConeRight.renderOBJ(_camera, 1);
            mediumConeLeft.renderOBJ(_camera, 1);
            mediumConeRight.renderOBJ(_camera, 1);
            smallConeLeft.renderOBJ(_camera, 1);
            smallConeRight.renderOBJ(_camera, 1);
            // snowman
            snowmanBawah.renderOBJ2(_camera, 1);
            snowmanTengah.renderOBJ2(_camera, 1);
            snowmanAtas.renderOBJ2(_camera, 1);
            topiSnowman.renderOBJ2(_camera, 1);
            syalSnowman.renderOBJ2(_camera, 1);
            leftEye.renderOBJ2(_camera, 1);
            rightEye.renderOBJ2(_camera, 1);
            leftHand.renderOBJ2(_camera, 1);
            rightHand.renderOBJ2(_camera, 1);
            // rumah clara 1
            badanrumahClara1.renderOBJ(_camera, 1);
            pinturumahClara1.renderOBJ(_camera, 1);
            jendelarumahClara1.renderOBJ(_camera, 1);
            ataprumahClara1.renderOBJ(_camera, 1);
            // tree
            tree1.renderOBJ2(_camera, 2);
            tree2.renderOBJ2(_camera, 2);
            tree3.renderOBJ(_camera, 2);
            // rumah jenn 1
            atapRumahJenn1.renderOBJ(_camera, 1);
            atapRumahJenn2.renderOBJ(_camera, 1); 
            rumahJenn.renderOBJ(_camera, 1);
            pintuRumahJenn.renderOBJ(_camera, 1);
            jendelaRumahJenn.renderOBJ(_camera, 1);
            // gazebo
            gazeboAtas.renderOBJ(_camera, 1);
            tiang1.renderOBJ(_camera, 1);
            tiang2.renderOBJ(_camera, 1);
            tiang3.renderOBJ(_camera, 1);
            tiang4.renderOBJ(_camera, 1);
            tiang5.renderOBJ(_camera, 1);
            tiang6.renderOBJ(_camera, 1);
            alasGazebo.renderOBJ(_camera, 1);
            kayu1.renderOBJ(_camera, 1);
            kayu2.renderOBJ(_camera, 1);
            kayuMini1.renderOBJ(_camera, 1);
            kayuMini2.renderOBJ(_camera, 1);
            kayuMini3.renderOBJ(_camera, 1);
            kayuMini4.renderOBJ(_camera, 1);
            kayuMini5.renderOBJ(_camera, 1);
            kayuMini6.renderOBJ(_camera, 1);
            kayuMini7.renderOBJ(_camera, 1);
            kayuMini8.renderOBJ(_camera, 1);
            kayu3.renderOBJ(_camera, 1);
            kayu4.renderOBJ(_camera, 1);
            kayu34Mini1.renderOBJ(_camera, 1);
            kayu34Mini2.renderOBJ(_camera, 1);
            kayu34Mini3.renderOBJ(_camera, 1);
            kayu34Mini4.renderOBJ(_camera, 1);
            kayu34Mini5.renderOBJ(_camera, 1);
            kayu34Mini6.renderOBJ(_camera, 1);
            kayu34Mini7.renderOBJ(_camera, 1);
            kayu5.renderOBJ(_camera, 1);
            kayu6.renderOBJ(_camera, 1);
            kayu56Mini1.renderOBJ(_camera, 1);
            kayu56Mini2.renderOBJ(_camera, 1);
            kayu56Mini3.renderOBJ(_camera, 1);
            kayu56Mini4.renderOBJ(_camera, 1);
            kayu56Mini5.renderOBJ(_camera, 1);
            kayu56Mini6.renderOBJ(_camera, 1);
            kayu56Mini7.renderOBJ(_camera, 1);
            kayu7.renderOBJ(_camera, 1);
            kayu8.renderOBJ(_camera, 1);
            kayu78Mini1.renderOBJ(_camera, 1);
            kayu78Mini2.renderOBJ(_camera, 1);
            kayu78Mini3.renderOBJ(_camera, 1);
            kayu78Mini4.renderOBJ(_camera, 1);
            kayu78Mini5.renderOBJ(_camera, 1);
            kayu78Mini6.renderOBJ(_camera, 1);
            kayu78Mini7.renderOBJ(_camera, 1);
            kayu78Mini8.renderOBJ(_camera, 1);
            // rumah jenn 2
            rumahPinggir2.renderOBJ(_camera, 1);
            atapPinggir2.renderOBJ(_camera, 1);
            pintuPinggir2.renderOBJ(_camera, 1);
            rumahJenn2.renderOBJ(_camera, 1);
            pintuRumah2.renderOBJ(_camera, 1);
            atapRumah2.renderOBJ(_camera, 1);
            rumahMini2.renderOBJ(_camera, 1);
            atapRumahMini2.renderOBJ(_camera, 1);
            
            SwapBuffers();
            base.OnRenderFrame(args);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            const float cameraSpeed = 0.1f;
            // Escape keyboard
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }
            // Zoom in
            if (KeyboardState.IsKeyDown(Keys.I))
            {
                _camera.Fov -= 0.1f;
            }
            // Zoom out
            if (KeyboardState.IsKeyDown(Keys.O))
            {
                _camera.Fov += 0.1f;
            }
            // Rotasi X di pivot Camera
            if (KeyboardState.IsKeyDown(Keys.T)) // kamera liat ke atas 
            {
                _camera.Pitch += 0.05f;
            }
            if (KeyboardState.IsKeyDown(Keys.G)) // kamera liat ke bawah 
            {
                _camera.Pitch -= 0.05f;
            }
            // Rotasi Y di pivot Camera
            if (KeyboardState.IsKeyDown(Keys.F)) // kamera liat ke kiri 
            {
                _camera.Yaw -= 0.05f;
            }
            if (KeyboardState.IsKeyDown(Keys.H)) // kamera liat ke kanan 
            {
                _camera.Yaw += 0.05f;
            }

            if (KeyboardState.IsKeyDown(Keys.W)) // kamera maju
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.S)) // kamera mundur
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.A)) // kamera ke kiri 
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.D)) // kamera ke kanan 
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time;
            }
            
            if (KeyboardState.IsKeyDown(Keys.Space)) // naik
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.LeftControl)) // turun
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time;
            }

            const float _rotationSpeed = 0.02f;
            
            if (KeyboardState.IsKeyDown(Keys.K)) // rotasi terhadap sumbu x atas
            {
                _objectPos *= 2;
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objectPos;
                _camera.Pitch -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position, generateArbRotationMatrix(axis, _objectPos, _rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;

                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
                _objectPos /= 2;

            }
            if (KeyboardState.IsKeyDown(Keys.M)) // rotasi terhadap sumbu x bawah
            {
                _objectPos *= 2;
                var axis = new Vector3(1, 0, 0); 
                _camera.Position -= _objectPos;
                _camera.Pitch += _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position, generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;

                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
                _objectPos /= 2;
            }
            if (KeyboardState.IsKeyDown(Keys.Comma)) // rotasi terhadap sumbu y kanan
            {
                _objectPos *= 2;
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Yaw -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;

                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
                _objectPos /= 2;
            }
            if (KeyboardState.IsKeyDown(Keys.M)) // rotasi terhadap sumbu y kiri
            {
                _objectPos *= 2;
                var axis = new Vector3(0, 1, 0); 
                _camera.Position -= _objectPos;
                _camera.Yaw += _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, _rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;

                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
                _objectPos /= 2;
            }
            if (KeyboardState.IsKeyDown(Keys.J)) // rotasi terhadap sumbu z kiri
            {
                _objectPos *= 2;
                var axis = new Vector3(0, 0, 1); 
                _camera.Position -= _objectPos;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, _rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;

                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
                _objectPos /= 2;
            }
            if (KeyboardState.IsKeyDown(Keys.L)) // rotasi terhadap sumbu z kanan
            {
                _objectPos *= 2;
                var axis = new Vector3(0, 0, 1);
                _camera.Position -= _objectPos;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, _rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;

                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
                _objectPos /= 2;
            }

            if (!IsFocused)
            {
                return;
            }

            const float sensitivity = 0.2f;

            if (_firstMove)
            {
                _lastMousePosition = new Vector2(MouseState.X, MouseState.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = MouseState.X - _lastMousePosition.X;
                var deltaY = MouseState.Y - _lastMousePosition.Y;

                _lastMousePosition = new Vector2(MouseState.X, MouseState.Y);

                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity;
            }

            base.OnUpdateFrame(args);
        }
    }
}
