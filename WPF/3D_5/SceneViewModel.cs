using System.Windows.Media.Media3D;
using _3D_5.Utilities3D;

namespace _3D_5
{
    public class SceneViewModel
    {
        public MeshGeometry3D SphereMesh { get; }
        public MeshGeometry3D RectangleMesh { get; }

        public SceneViewModel()
        {
            SphereMesh = CreateSphere();
            RectangleMesh = CreateRectangle();
        }

        private MeshGeometry3D CreateSphere()
        {
            var mb = new MeshBuilder();
            mb.AddSphere(new Point3D(0, 0, 0), radius: 1.0);
            return mb.ToMesh();
        }

        private MeshGeometry3D CreateRectangle()
        {
            var mb = new MeshBuilder();

            mb.AddQuad(
                new Point3D(-1, 0, -2),
                new Point3D(1, 0, -2),
                new Point3D(1, -1, -2),
                new Point3D(-1, -1, -2)
            );

            return mb.ToMesh();
        }
    }
}
