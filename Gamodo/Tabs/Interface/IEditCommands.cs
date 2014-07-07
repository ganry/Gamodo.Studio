using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gamodo.Tabs.Interface
{
    interface IEditCommands
    {
        bool CanCut();
        bool CanCopy();
        bool CanPaste();
        bool CanRedo();
        bool CanUndo();

        void Cut();
        void Copy();
        void Paste();
        void Redo();
        void Undo();
    }
}
