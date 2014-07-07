using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gamodo.Tabs.Interface
{
    public interface ISaveAble
    {
        bool CanSave();
        bool Save();
        bool SaveAs();
    }
}
