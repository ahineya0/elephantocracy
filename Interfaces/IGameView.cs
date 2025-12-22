using elephantocracy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Interfaces
{
    public interface IGameView
    {
        void RefreshView();
        void ShowError(string message);
        void ShowMessage(string message);
        int CellSize { get; }
    }
}
