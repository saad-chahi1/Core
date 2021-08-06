using Prysm.AppVideo;
using System.Threading.Tasks;

namespace SSI.GeoVision.Player
{
    /// <summary>
    /// Logique d'interaction pour GeoVisionPlayer.xaml
    /// </summary>
    public partial class GeoVisionPlayer : PlayerBaseControl, IPlayerLive, IPlayerPlayback, IPlayerPtz, IPlayerVideoDevice
    {

        public GeoVisionPlayer()
        {
            InitializeComponent();
        }

        public override async Task Connect(string address, string parameters)
        {
            
        }

        public override async Task Play()
        {
            
        }
    }
}
