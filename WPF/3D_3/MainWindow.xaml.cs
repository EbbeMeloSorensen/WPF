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

namespace _3D_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CameraViewModel Cam => (CameraViewModel) DataContext;

        private Point _lastPos;
        private bool _leftDown;
        private bool _rightDown;

        public MainWindow()
        {
            InitializeComponent();
            SetupScene();
        }

        private void Viewport_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _lastPos = e.GetPosition(this);
            _leftDown = e.LeftButton == MouseButtonState.Pressed;
            _rightDown = e.RightButton == MouseButtonState.Pressed;
            Mouse.Capture(viewport);
        }

        private void Viewport_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_leftDown && !_rightDown) return;

            var pos = e.GetPosition(this);
            var dx = pos.X - _lastPos.X;
            var dy = pos.Y - _lastPos.Y;
            _lastPos = pos;

            if (_leftDown)
            {
                // Orbit: adjust yaw/pitch
                Cam.Yaw += dx * 0.4;
                Cam.Pitch -= dy * 0.4;
            }
            else if (_rightDown)
            {
                // Pan: move target horizontally
                PanCamera(dx, dy);
            }
        }

        private void Viewport_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            // Zoom: adjust distance
            Cam.Distance *= e.Delta > 0 ? 0.9 : 1.1;
        }

        private void PanCamera(double dx, double dy)
        {
            // Convert pixels into world units
            double scale = Cam.Distance * 0.0015;

            // Pan left/right based on camera orientation
            var right = Vector3D.CrossProduct(Cam.LookDirection, new Vector3D(0, 1, 0));
            right.Normalize();
            var up = Vector3D.CrossProduct(right, Cam.LookDirection);
            up.Normalize();

            Cam.Target += (-right * dx * scale) + (up * dy * scale);
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