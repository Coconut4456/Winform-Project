namespace RedHorizon1.data.script;

public class LandRepository
{
    private readonly List<Control> _lands;
    private int[] _lineIndexes;

    public LandRepository()
    {
        _lands = new List<Control>();
    }

    public int DisplayLands()
    {
        return _lands.Count;
    }

    public void SetLandLineIndex(int x, int y)
    {
        _lineIndexes = [x, y];
    }
    

    public void AddLands()
    {
        int lineX = _lineIndexes[0];
        int lineY = _lineIndexes[1];
        int totalNum = lineX * lineY;
        
        for (int i = 0; i < totalNum; i++)
        {
                Label label = new Label();
                label.Name = "Land" + totalNum + 1;
                label.Size = new Size(25, 25);
                label.BorderStyle = BorderStyle.FixedSingle;
                _lands.Add(label);
        }
    }
    
    // 라벨 정렬 메서드 만드러야함
}