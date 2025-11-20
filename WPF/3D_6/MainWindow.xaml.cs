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
using System.Windows.Threading;

namespace _3D_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _angle = 0;
        private DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();
            Sphere.Geometry = CreateSphere();

            StartLightAnimation();
        }

        private void StartLightAnimation()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(30);
            _timer.Tick += (s, e) =>
            {
                _angle += 0.05;
                double x = Math.Cos(_angle) * 2;
                double z = Math.Sin(_angle) * 2;

                PlayerLight.Position = new Point3D(x, 1.5, z);
            };
            _timer.Start();
        }

        private MeshGeometry3D CreateSphere()
        {
            var mesh = new MeshGeometry3D();
            int slices = 32;
            int stacks = 16;

            for (int i = 0; i <= stacks; i++)
            {
                double phi = Math.PI * i / stacks;

                for (int j = 0; j <= slices; j++)
                {
                    double theta = 2 * Math.PI * j / slices;

                    double x = Math.Sin(phi) * Math.Cos(theta);
                    double y = Math.Cos(phi);
                    double z = Math.Sin(phi) * Math.Sin(theta);

                    mesh.Positions.Add(new Point3D(x, y, z));
                    mesh.Normals.Add(new Vector3D(x, y, z));
                }
            }

            int stride = slices + 1;

            for (int i = 0; i < stacks; i++)
            {
                for (int j = 0; j < slices; j++)
                {
                    int p0 = i * stride + j;
                    int p1 = p0 + 1;
                    int p2 = p0 + stride;
                    int p3 = p2 + 1;

                    mesh.TriangleIndices.Add(p0);
                    mesh.TriangleIndices.Add(p2);
                    mesh.TriangleIndices.Add(p1);

                    mesh.TriangleIndices.Add(p1);
                    mesh.TriangleIndices.Add(p2);
                    mesh.TriangleIndices.Add(p3);
                }
            }

            return mesh;
        }
    }
}