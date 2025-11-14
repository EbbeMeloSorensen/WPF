using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3D_1
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
            // --- Camera ---
            var camera = new PerspectiveCamera(
                new Point3D(0, 1, 4),    // Position
                new Vector3D(0, -0.2, -1),  // Look direction
                new Vector3D(0, 1, 0),      // Up direction
                45                           // Field of view
            );

            viewport.Camera = camera;

            // --- Lighting ---
            var light = new DirectionalLight(Colors.White, new Vector3D(-0.5, -1, -0.5));
            var lightModel = new ModelVisual3D { Content = light };
            viewport.Children.Add(lightModel);

            // --- Rectangle (a simple quad) ---
            var rectangle = CreateRectangle(
                new Point3D(-1, 0, 0),
                new Point3D(1, 0, 0),
                new Point3D(1, -1, 0),
                new Point3D(-1, -1, 0),
                Colors.SkyBlue
            );
            viewport.Children.Add(rectangle);

            // --- Sphere ---
            var sphere = CreateSphere(center: new Point3D(0, 0.5, 1), radius: 0.5, slices: 20, stacks: 20, color: Colors.Orange);
            viewport.Children.Add(sphere);
        }

        // ============================================================
        // Rectangle mesh
        // ============================================================
        private ModelVisual3D CreateRectangle(Point3D p1, Point3D p2, Point3D p3, Point3D p4, Color color)
        {
            var mesh = new MeshGeometry3D
            {
                Positions = new Point3DCollection { p1, p2, p3, p4 },
                TriangleIndices = new Int32Collection { 0, 2, 1, 0, 3, 2 },
                Normals = new Vector3DCollection { new Vector3D(0, 0, 1) }
            };

            var material = new DiffuseMaterial(new SolidColorBrush(color));
            var model = new GeometryModel3D(mesh, material);
            return new ModelVisual3D { Content = model };
        }

        // ============================================================
        // Sphere mesh (simple code-generated UV sphere)
        // ============================================================
        private ModelVisual3D CreateSphere(Point3D center, double radius, int slices, int stacks, Color color)
        {
            var mesh = new MeshGeometry3D();

            // Create vertices
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

            // Create triangle indices
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
            var model = new GeometryModel3D(mesh, material);
            return new ModelVisual3D { Content = model };
        }
    }
}