using System.Windows.Forms;

namespace Halloumi.Abettor.Plugins
{
    public interface IPlugin
    {
        ToolStripItemCollection GetMenuItems();
        void Start();
        void Stop();
    }
}
