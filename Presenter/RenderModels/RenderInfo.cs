using System;
using System.Collections.Generic;
using System.Text;

namespace elephantocracy.Presenter.RenderModels
{
    public class SectorRenderInfo(int X, int Y, SectorType Type);
    public class ObjectRenderInfo(int X, int Y, RenderObjectType Type);

    public enum RenderObjectType
    {
        Player,
        Enemy,
        Bubble
    }
}
