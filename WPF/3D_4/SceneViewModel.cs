using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace _3D_4
{
    public class SceneViewModel : INotifyPropertyChanged
    {
        private Model3DGroup _scene;

        public Model3DGroup Scene
        {
            get => _scene;
            private set { _scene = value; OnPropertyChanged(); }
        }

        public SceneViewModel()
        {
            BuildScene();
        }

        private void BuildScene()
        {
            var group = new Model3DGroup();

            // Light
            group.Children.Add(new DirectionalLight(Colors.White,
                new Vector3D(-0.5, -1, -0.5)));

            // Rectangle
            group.Children.Add(CreateRectangle(
                new Point3D(-1, 0, -1),
                new Point3D(1, 0, -1),
                new Point3D(1, -1, -1),
                new Point3D(-1, -1, -1),
                Colors.SkyBlue));

            // Sphere
            group.Children.Add(CreateSphere(
                center: new Point3D(0, 0.5, 1),
                radius: 0.5,
                slices: 20,
                stacks: 20,
                color: Colors.Orange));

            Scene = group;
        }

        // ------------------- Rectangle ------------------------
        private GeometryModel3D CreateRectangle(Point3D p1, Point3D p2, Point3D p3, Point3D p4, Color color)
        {
            var mesh = new MeshGeometry3D
            {
                Positions = new Point3DCollection { p1, p2, p3, p4 },
                TriangleIndices = new Int32Collection { 0, 2, 1, 0, 3, 2 }
            };

            var material = new DiffuseMaterial(new SolidColorBrush(color));
            return new GeometryModel3D(mesh, material);
        }

        // ------------------- Sphere ------------------------
        private GeometryModel3D CreateSphere(
            Point3D center, double radius,
            int slices, int stacks, Color color)
        {
            var mesh = new MeshGeometry3D();

            // Vertices
            for (int stack = 0; stack <= stacks; stack++)
            {
                double phi = Math.PI * stack / stacks;
                double y = Math.Cos(phi);
                double r = Math.Sin(phi);

                for (int slice = 0; slice <= slices; slice++)
                {
                    double theta = 2 * Math.PI * slice / slices;
                    double x = r * Math.Cos(theta);
                    double z = r * Math.Sin(theta);

                    mesh.Positions.Add(new Point3D(
                        center.X + radius * x,
                        center.Y + radius * y,
                        center.Z + radius * z));

                    mesh.Normals.Add(new Vector3D(x, y, z));
                }
            }

            // Triangles
            for (int stack = 0; stack < stacks; stack++)
            {
                for (int slice = 0; slice < slices; slice++)
                {
                    int first = (stack * (slices + 1)) + slice;
                    int second = first + slices + 1;

                    mesh.TriangleIndices.Add(first);
                    mesh.TriangleIndices.Add(second);
                    mesh.TriangleIndices.Add(first + 1);

                    mesh.TriangleIndices.Add(first + 1);
                    mesh.TriangleIndices.Add(second);
                    mesh.TriangleIndices.Add(second + 1);
                }
            }

            var material = new DiffuseMaterial(new SolidColorBrush(color));
            return new GeometryModel3D(mesh, material);
        }

        // ------------------- INotifyPropertyChanged ------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
