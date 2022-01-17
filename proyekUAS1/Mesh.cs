using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace proyekUAS1
{
    class Mesh
    {
        protected List<Vector3> vertices = new List<Vector3>(); 
        protected List<Vector2> texture = new List<Vector2>();
        protected List<Vector3> normals = new List<Vector3>();
        protected List<uint> indices = new List<uint>();

        protected int VBO;
        protected int VAO;
        protected int EBO;

        protected Shader _shader;
        protected Matrix4 transform;
        Matrix4 view;
        Matrix4 projection;

        //lighting
        private int _vaoLamp;
        private Shader _lampShader;
        private Shader _lightingShader;

        private Texture _diffuseMap;
        private Texture _specularMap;

        //protected int count = 0;

        public Mesh()
        {
        }

        public void setupObject(float Sizex, float Sizey)
        {
            //GL.Enable(EnableCap.DepthTest);
            transform = Matrix4.Identity;

            VBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, vertices.Count * Vector3.SizeInBytes,
                vertices.ToArray(), BufferUsageHint.StaticDraw);

            VAO = GL.GenVertexArray();
            GL.BindVertexArray(VAO);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            _shader = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Shaders/colour.frag");
            _shader.Use();

            scale(0.4f);

            view = Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);
            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), Sizex / Sizey, 0.1f, 100.0f);
        }

        public void setEBO()
        {
            EBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer,
                indices.Count * sizeof(uint),
                indices.ToArray(), BufferUsageHint.StaticDraw);
        }

        public void setOBJ(string pathobj, string pathdif, string pathspec)
        {
            transform = Matrix4.Identity;
            LoadObjFile(pathobj);

            VBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, vertices.Count * Vector3.SizeInBytes,
                vertices.ToArray(), BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            VAO = GL.GenVertexArray();
            GL.BindVertexArray(VAO);

            _lightingShader = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Shaders/lightingOBJ.frag");
            _lampShader = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/proyekUAS1/proyekUAS1/Shaders/shader.frag");

            var vertexLocation = _lightingShader.GetAttribLocation("aPosition");
            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            var normalLocation = _lightingShader.GetAttribLocation("aNormal");
            GL.EnableVertexAttribArray(normalLocation);
            GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            var texCoordLocation = _lightingShader.GetAttribLocation("aTexCoords");
            GL.EnableVertexAttribArray(texCoordLocation);
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0);

            _vaoLamp = GL.GenVertexArray();
            GL.BindVertexArray(_vaoLamp);

            vertexLocation = _lampShader.GetAttribLocation("aPosition");
            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            _diffuseMap = Texture.LoadFromFile(pathdif);
            _specularMap = Texture.LoadFromFile(pathspec);
        }

        public void render(Camera _camera, Vector3 _color)
        {
            _shader.Use();

            _shader.SetVector3("my_color", _color);
            _shader.SetMatrix4("transform", transform);
            _shader.SetMatrix4("view", _camera.GetViewMatrix());
            _shader.SetMatrix4("projection", _camera.GetProjectionMatrix());
            
            GL.BindVertexArray(VAO);

            GL.DrawElements(PrimitiveType.TriangleFan,
                indices.Count,
                DrawElementsType.UnsignedInt, 0);
        }

        public void renderQuadric(Camera _camera, Vector3 _color)
        {
            _shader.Use();

            _shader.SetVector3("my_color", _color);
            _shader.SetMatrix4("transform", transform);
            _shader.SetMatrix4("view", _camera.GetViewMatrix());
            _shader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            GL.BindVertexArray(VAO);

            GL.DrawElements(PrimitiveType.TriangleStripAdjacency,
                indices.Count,
                DrawElementsType.UnsignedInt, 0);
        }

        public void renderOBJ(Camera _camera, int n)
        {
            GL.BindVertexArray(VAO);

            _diffuseMap.Use(TextureUnit.Texture0);
            _specularMap.Use(TextureUnit.Texture1);
            _lightingShader.Use();

            _lightingShader.SetMatrix4("transform", transform);
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("viewPos", _camera.Position);
            // material setting
            _lightingShader.SetInt("material.diffuse", 0);
            _lightingShader.SetInt("material.specular", 1);
            _lightingShader.SetFloat("material.shininess", 32.0f);

            _lightingShader.SetVector3("light.direction", new Vector3(0.4f, 1.0f, -0.3f));
            _lightingShader.SetVector3("light.ambient", new Vector3(0.2f));
            _lightingShader.SetVector3("light.diffuse", new Vector3(0.7f));
            _lightingShader.SetVector3("light.specular", new Vector3(1.0f, 1.0f, 1.0f));

            if (n == 1)
            {
                GL.DrawElements(PrimitiveType.TriangleFan, indices.Count, DrawElementsType.UnsignedInt, indices.ToArray());
            }
            else if (n == 2)
            {
                GL.DrawElements(PrimitiveType.LineStrip, indices.Count, DrawElementsType.UnsignedInt, indices.ToArray());
            }
        }

        public void renderOBJ2(Camera _camera, int n)
        {
            GL.BindVertexArray(VAO);

            _diffuseMap.Use(TextureUnit.Texture0);
            _specularMap.Use(TextureUnit.Texture1);
            _lightingShader.Use();

            _lightingShader.SetMatrix4("transform", transform);
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("viewPos", _camera.Position);
            // material setting
            _lightingShader.SetInt("material.diffuse", 0);
            _lightingShader.SetInt("material.specular", 1);
            _lightingShader.SetFloat("material.shininess", 32.0f);

            //_lightingShader.SetVector3("light.direction", new Vector3(0.4f, 1.0f, -0.3f));
            _lightingShader.SetVector3("light.direction", new Vector3(-0.4f, 1.0f, -0.3f));
            _lightingShader.SetVector3("light.ambient", new Vector3(0.2f));
            _lightingShader.SetVector3("light.diffuse", new Vector3(0.7f));
            _lightingShader.SetVector3("light.specular", new Vector3(1.0f, 1.0f, 1.0f));

            if (n == 1)
            {
                GL.DrawElements(PrimitiveType.TriangleFan, indices.Count, DrawElementsType.UnsignedInt, indices.ToArray());
            }
            else if (n == 2)
            {
                GL.DrawElements(PrimitiveType.LineStrip, indices.Count, DrawElementsType.UnsignedInt, indices.ToArray());
            }
        }

        public void LoadObjFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Unable to open \"" + path + "\", does not exist.");
            }

            using (StreamReader streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    List<string> words = new List<string>(streamReader.ReadLine().ToLower().Split(' '));
                    words.RemoveAll(s => s == string.Empty);

                    if (words.Count == 0)
                        continue;

                    string type = words[0];

                    words.RemoveAt(0);


                    switch (type)
                    {
                        case "v":
                            vertices.Add(new Vector3(float.Parse(words[0]) / 10, float.Parse(words[1]) / 10, float.Parse(words[2]) / 10));
                            break;

                        case "vn":
                            normals.Add(new Vector3(float.Parse(words[0]), float.Parse(words[1]), float.Parse(words[2])));
                            //vertices.Add(new Vector3(float.Parse(words[0]), float.Parse(words[1]), float.Parse(words[2])));
                            break;

                        case "vt":
                            texture.Add(new Vector2(float.Parse(words[0]), float.Parse(words[1])));
                            break;
                        // face
                        case "f":
                            foreach (string w in words)
                            {
                                if (w.Length == 0)
                                    continue;

                                string[] comps = w.Split('/');

                                indices.Add(uint.Parse(comps[0]) - 1);

                            }
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        public void createBoxVertices(float _l, float _w, float _h, float x, float y, float z)
        {
            float _positionX = x;
            float _positionY = y;
            float _positionZ = z;

            Vector3 temp_vector;
            Vector3 temp_normal;

            // Titik 1 kiri atas depan 
            temp_vector.X = _positionX - _l / 2.0f; // x 
            temp_vector.Y = _positionY + _h / 2.0f; // y
            temp_vector.Z = _positionZ - _w / 2.0f; // z
            temp_normal = new Vector3(0.0f, 0.0f, -1.0f);
            vertices.Add(temp_vector);
            //vertices.Add(temp_normal);

            // Titik 2 kanan atas depan 
            temp_vector.X = _positionX + _l / 2.0f; // x
            temp_vector.Y = _positionY + _h / 2.0f; // y
            temp_vector.Z = _positionZ - _w / 2.0f; // z
            temp_normal = new Vector3(0.0f, 0.0f, -1.0f);
            vertices.Add(temp_vector);
            //vertices.Add(temp_normal);

            // Titik 3 kiri bawah depan
            temp_vector.X = _positionX - _l / 2.0f; // x
            temp_vector.Y = _positionY - _h / 2.0f; // y
            temp_vector.Z = _positionZ - _w / 2.0f; // z
            temp_normal = new Vector3(0.0f, 0.0f,- 1.0f);
            vertices.Add(temp_vector);
            //vertices.Add(temp_normal);

            // Titik 4 kanan bawah depan
            temp_vector.X = _positionX + _l / 2.0f; // x
            temp_vector.Y = _positionY - _h / 2.0f; // y
            temp_vector.Z = _positionZ - _w / 2.0f; // z
            temp_normal = new Vector3(0.0f, 0.0f, -1.0f);
            vertices.Add(temp_vector);
            //vertices.Add(temp_normal);

            // Titik 5 kiri atas belakang 
            temp_vector.X = _positionX - _l / 2.0f; // x
            temp_vector.Y = _positionY + _h / 2.0f; // y
            temp_vector.Z = _positionZ + _w / 2.0f; // z

            vertices.Add(temp_vector);
            //vertices.Add(temp_normal);

            // Titik 6 kanan atas belakang 
            temp_vector.X = _positionX + _l / 2.0f; // x
            temp_vector.Y = _positionY + _h / 2.0f; // y
            temp_vector.Z = _positionZ + _w / 2.0f; // z

            vertices.Add(temp_vector);
            //vertices.Add(temp_normal);

            // Titik 7 kiri bawah belakang 
            temp_vector.X = _positionX - _l / 2.0f; // x
            temp_vector.Y = _positionY - _h / 2.0f; // y
            temp_vector.Z = _positionZ + _w / 2.0f; // z

            vertices.Add(temp_vector);
            //vertices.Add(temp_normal);

            // Titik 8 kanan bawah belakang 
            temp_vector.X = _positionX + _l / 2.0f; // x
            temp_vector.Y = _positionY - _h / 2.0f; // y
            temp_vector.Z = _positionZ + _w / 2.0f; // z

            vertices.Add(temp_vector);
            //vertices.Add(temp_normal);

            
            indices = new List<uint> {
                // Segitiga Depan 1
                0, 1, 2,
                // Segitiga Depan 2
                1, 2, 3,
                // Segitiga Atas 1
                0, 4, 5,
                // Segitiga Atas 2
                0, 1, 5,
                // Segitiga Kanan 1
                1, 3, 5,
                // Segitiga Kanan 2
                3, 5, 7,
                // Segitiga Kiri 1
                0, 2, 4,
                // Segitiga Kiri 2
                2, 4, 6,
                // Segitiga Belakang 1
                4, 5, 6,
                // Segitiga Belakang 2
                5, 6, 7,
                // Segitiga Bawah 1
                2, 3, 6,
                // Segitiga Bawah 2
                3, 6, 7
            };

        }

        public void rotate(float _x, float _y, float _z)
        {
            transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(_x));
            transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_y));
            transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(_z));
        }

        public void translate(float _x, float _y, float _z)
        {
            transform = transform * Matrix4.CreateTranslation(_x, _y, _z);
        }

        public void scale(float x)
        {
            transform = transform * Matrix4.CreateScale(x);
        }

    }
}
