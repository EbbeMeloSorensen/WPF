using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace _3D_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetupScene();
        }

        private void SetupScene()
        {
            // --- Lighting ---
            var light = new DirectionalLight(Colors.White, new Vector3D(-0.5, -1, -0.5));
            viewport.Children.Add(new ModelVisual3D { Content = light });

            // --- Rectangle ---
            viewport.Children.Add(CreateRectangle(
                new Point3D(-1, 0, 0),
                new Point3D(1, 0, 0),
                new Point3D(1, -1, 0),
                new Point3D(-1, -1, 0),
                Colors.SkyBlue));

            // --- Sphere ---
            viewport.Children.Add(CreateSphere(
                center: new Point3D(0, 0.5, 1),
                radius: 0.5,
                slices: 20,
                stacks: 20,
                color: Colors.Orange));
        }

        private ModelVisual3D CreateRectangle(Point3D p1, Point3D p2, Point3D p3, Point3D p4, Color color)
        {
            var mesh = new MeshGeometry3D
            {
                Positions = new Point3DCollection { p1, p2, p3, p4 },
                TriangleIndices = new Int32Collection { 0, 2, 1, 0, 3, 2 },
            };

            var material = new DiffuseMaterial(new SolidColorBrush(color));

            return new ModelVisual3D
            {
                Content = new GeometryModel3D(mesh, material)
            };
        }

        private ModelVisual3D CreateSphere(Point3D center, double radius, int slices, int stacks, Color color)
        {
            var mesh = new MeshGeometry3D();

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

            return new ModelVisual3D
            {
                Content = new GeometryModel3D(mesh, material)
            };
        }
    }
}