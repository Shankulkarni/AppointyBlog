using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointy.Portable.Helpers
{
    public interface IShare
    {
        void ShareText(string text);
        void LaunchBrowser(string url);
    }
}
