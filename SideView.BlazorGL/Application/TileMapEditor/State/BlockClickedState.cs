using Pathfinding2D.SideView.BlazorGL.Application.TileMap;

namespace Pathfinding2D.SideView.BlazorGL.Application.TileMapEditor.State;

public class BlockClickedState : CellClickedState
{
    protected override CellType NewCellType => CellType.Ladder;
}