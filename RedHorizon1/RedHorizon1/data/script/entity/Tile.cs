using RedHorizon1.data.script.terrain;

namespace RedHorizon1.data.script.entity;

public class Tile
{
    public int X { get; set; } // 가로 위치
    public int Y { get; set; } // 세로 위치
    public TerrainType TerrainType; // 지형 유형
    public int TileId { get; set; } // 타일 식별번호
    public int? UnitId; // 유닛 식별번호
    public int? PlayerId; // 플레이어 식별번호
    public int? CityId; // 도시 식별번호
    public bool IsSelected { get; set; } // 선택 여부
    public int? Unit; // 유닛 개수
}