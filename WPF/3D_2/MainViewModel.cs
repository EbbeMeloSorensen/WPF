using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Media3D;

namespace _3D_2
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private double _cameraPositionX;
        private Point3D _cameraPosition = new Point3D(0, 1, 4);

        public double CameraPositionX
        {
            get => _cameraPositionX;
            set
            {
                _cameraPositionX = value;
                CameraPosition = new Point3D(CameraPositionX, CameraPosition.Y, CameraPosition.Z);
                OnPropertyChanged();
            }
        }

        public Point3D CameraPosition
        {
            get => _cameraPosition;
            set
            {
                if (_cameraPosition == value) return;
                _cameraPosition = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
