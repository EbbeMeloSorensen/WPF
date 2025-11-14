using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Media3D;

namespace _3D_3
{
    public class CameraViewModel : INotifyPropertyChanged
    {
        // Orbit parameters
        private double _yaw = 45;     // degrees
        private double _pitch = 20;   // degrees
        private double _distance = 5; // from target
        private Point3D _target = new Point3D(0, 0, 0);

        public double Yaw
        {
            get => _yaw;
            set { _yaw = value; OnPropertyChanged(); UpdateCamera(); }
        }

        public double Pitch
        {
            get => _pitch;
            set { _pitch = Math.Clamp(value, -89, 89); OnPropertyChanged(); UpdateCamera(); }
        }

        public double Distance
        {
            get => _distance;
            set { _distance = Math.Max(0.1, value); OnPropertyChanged(); UpdateCamera(); }
        }

        public Point3D Target
        {
            get => _target;
            set { _target = value; OnPropertyChanged(); UpdateCamera(); }
        }

        // Output (bound to camera)
        private Point3D _cameraPosition;
        private Vector3D _lookDirection;

        public Point3D CameraPosition
        {
            get => _cameraPosition;
            private set { _cameraPosition = value; OnPropertyChanged(); }
        }

        public Vector3D LookDirection
        {
            get => _lookDirection;
            private set { _lookDirection = value; OnPropertyChanged(); }
        }

        public CameraViewModel()
        {
            UpdateCamera();
        }

        private void UpdateCamera()
        {
            // Convert spherical to Cartesian
            double yawRad = Yaw * Math.PI / 180;
            double pitchRad = Pitch * Math.PI / 180;

            double x = Distance * Math.Cos(pitchRad) * Math.Cos(yawRad);
            double y = Distance * Math.Sin(pitchRad);
            double z = Distance * Math.Cos(pitchRad) * Math.Sin(yawRad);

            CameraPosition = new Point3D(Target.X + x, Target.Y + y, Target.Z + z);
            LookDirection = Target - CameraPosition;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
