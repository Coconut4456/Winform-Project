using System.Diagnostics.CodeAnalysis;
using ColorBlock.Entity;
using Timer = System.Windows.Forms.Timer;
using System.Media;
using NAudio.Wave;

namespace ColorBlock;

public partial class Form1 : Form
{
    // start point 10,10
    // block = x23, y15
    private readonly List<WaveOutEvent> _waveOuts;
    private readonly List<AudioFileReader> _audioFileReaders;
    private readonly Block _tempBlock;
    private readonly Random _random;
    private readonly List<Block> _blockList;
    private readonly List<Color> _colorList;
    private readonly Timer _playTimeTimer;
    private readonly Size _blockSize;
    private readonly int _maxBlocks;
    private readonly int _rowSize;
    private readonly int _rowCount;
    private static int _playTime;
    private int _backColorCount;
    private int _countX;
    private int _countY;
    private int _countTime;
    private int _score;
    private int _highScore;

    public Form1()
    {
        InitializeComponent();
        
        {
            Initialize();
            ThemeChange();
        }

        {
            _tempBlock = new Block();
            _random = new Random();
            _blockList = new List<Block>();
            _playTimeTimer = new Timer();
            _playTimeTimer.Tick += Timer_Tick!;
            _waveOuts = new List<WaveOutEvent>();
            _audioFileReaders = new List<AudioFileReader>();
            this.KeyDown += Key_Down!;
        }

        {
            _blockSize = new Size(25, 25);
            _maxBlocks = 345;
            _rowSize = 23;
            _rowCount = 15;
            _playTime = 120;
            _highScore = 0;
            _backColorCount = 0;
            _playTimeTimer.Interval = 1000;
        }

        {
            this.KeyPreview = true;
            gameButton.Visible = true;
            scoreLabel.Visible = true;
            highScoreLabel.Visible = true;
            playTimeBar.Visible = false;
            borderButton.Visible = true;
            backColorButton.Visible = true;
        }

        {
            scoreLabel.TabStop = false;
            highScoreLabel.TabStop = false;
            playTimeBar.TabStop = false;
            borderButton.TabStop = false;
            backColorButton.TabStop = false;
            muteCheckBox.TabStop = false;
        }

        {
            scoreLabel.Text = @"";
            highScoreLabel.Text = @"";
            borderButton.Text = @"블럭 변경";
            backColorButton.Text = @"테마 변경";
            muteCheckBox.Text = @"음소거";
        }
        
        {
            _colorList =
            [
                Color.Crimson, Color.LightSalmon, Color.Khaki, Color.SpringGreen,
                Color.LightSeaGreen, Color.DarkSlateBlue, Color.DarkOrchid, Color.Orchid,
                Color.Gray, Color.Sienna
            ];
            
            highScoreLabel.ForeColor = Color.Red;
        }
    }

    // 초기 설정
    private void Initialize()
    {
        _countTime = _playTime;
        _countX = 0;
        _countY = 0;
        _score = 0;
        gameButton.Text = @"게임 시작";
        playTimeBar.Text = $@"{_playTime}";
        playTimeBar.Maximum = _playTime;
    }

    private void Key_Down(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.M)
        {
            new Form2().Show();
        }
    }

    // 게임 시작
    private void StartGame()
    {
        Initialize();
        ClearBlock();
        CreateBlock();
        Shuffle();
        SetTag();
        SetBlockPosition();
        _playTimeTimer.Start();
        _countTime = _playTime;
        playTimeBar.Visible = true;
        playTimeBar.Value = _countTime;
        gameButton.Text = @"중단";
        scoreLabel.Text = @$"{_score}";
        highScoreLabel.Text = $@"{_highScore}";
        gameBackGroundLabel.SendToBack();
    }

    // 게임 시간 반환
    public static int GetPlayTime()
    {
        return _playTime;
    }

    // 게임 시간 설정
    public static void SetPlayTime(int num)
    {
        switch (num)
        {
            case 0:
                _playTime -= 10;
                break;
            case 1:
                _playTime += 10;
                break;
        }
    }

    // 게임 중단
    private void StopGame()
    {
        DisableBlock();
        gameButton.Text = @"게임 시작";
        _playTimeTimer.Stop();
        playTimeBar.Visible = false;
    }

    // 블럭 위치 설정
    private void SetBlockPosition()
    {
        foreach (var block in _blockList)
        {
            // block.Label.Location = new Point(10 + _countX * _blockSpace, 10 + _countY * _blockSpace);
            block.Label.Location =
                new Point(10 + _countX * (_blockSize.Height + 5), 10 + _countY * (_blockSize.Width + 5));
            Controls.Add(block.Label);
            _countX++;

            if (_countX >= _rowSize)
            {
                _countX = 0;
                _countY++;
            }
        }
    }

    // 블럭 객체 생성
    private void CreateBlock()
    {
        // 10개의 색상 각각 20개의 블럭 생성 (총 20개씩 200개 = 최고점수 200점)
        foreach (var color in _colorList)
        {
            for (int j = 0; j < 20; j++)
            {
                Block block = new Block();
                block.Label.BackColor = color;
                block.Label.Click += Label_Click;
                block.Label.Size = _blockSize;
                block.Label.BorderStyle = _tempBlock.Label.BorderStyle;
                _blockList.Add(block);
            }
        }

        if (_blockList.Count < _maxBlocks)
        {
            int n = _maxBlocks - _blockList.Count; // n = 145

            for (int i = 0; i < n; i++)
            {
                Block block = new Block();
                block.Label.BackColor = Color.White;
                block.Label.Click += Label_Click;
                block.Label.Size = _blockSize;
                block.Label.BorderStyle = _tempBlock.Label.BorderStyle;
                _blockList.Add(block);
            }
        }
    }

    // 리스트 섞기
    private void Shuffle()
    {
        int n = _blockList.Count - 1;

        for (int i = n; i > 0 ; i--)
        {
            int j = _random.Next(i + 1);
            (_blockList[i], _blockList[j]) = (_blockList[j], _blockList[i]); // .
        }
    }

    // 라벨 태그에 index 값 부여
    private void SetTag()
    {
        int index = 0;
        
        foreach (var block in _blockList)
        {
            block.Label.Tag = index;
            index++;
        }
    }

    // 같은 색의 블럭 확인
    private void GetCheckList(int index)
    {
        int x = index % _rowSize; // 해당 index의 가로 행
        int y = index / _rowSize; // 해당 index의 세로 행

        // int leftEdge = y * _rowSize; // 가로행 첫번째 index
        // int rightEdge = y * _rowSize + (_rowSize - 1); // 가로행 마지막 index

        Dictionary<Color, List<int>> colors = new Dictionary<Color, List<int>>(); // color, index를 맵핑

        int checkIndex = index;

        // i = 클릭된 라벨의 가로 index
        for (int i = x; i >= 0; i--)
        {
            checkIndex -= 1; // 확인중인 index를 하나씩 줄이면서 탐색 (좌로 탐색)

            // 탐색중인 범위가 index 범위 초과시 중단
            if (checkIndex < 0)
            {
                break;
            }

            // 탐색중인 라벨이 비어있지 않을 경우 해당 라벨의 color와 index를 colors에 추가 key:color, value:index
            if (_blockList[checkIndex].Label.BackColor != Color.White)
            {
                Color color = _blockList[checkIndex].Label.BackColor;

                // colors에 추가하려는 color가 없을 경우 새 항목으로 추가
                if (!colors.ContainsKey(color))
                {
                    colors[color] = new List<int>();
                }

                colors[color].Add(checkIndex); // 추가하려는 color가 해당되는 key에 checkIndex를 value로 해당 List<int>에 추가
                break;
            }
        }

        checkIndex = index; // 재탐색을 위해 클릭된 블럭의 index 재할당

        for (int i = x; i < _rowSize; i++)
        {
            checkIndex += 1;

            if (checkIndex > 344)
            {
                break;
            }

            if (_blockList[checkIndex].Label.BackColor != Color.White)
            {
                Color color = _blockList[checkIndex].Label.BackColor;

                if (!colors.ContainsKey(color))
                {
                    colors[color] = new List<int>();
                }

                colors[color].Add(checkIndex);
                break;
            }
        }

        checkIndex = index;

        for (int i = y; i > 0; i--)
        {
            checkIndex -= _rowSize;

            if (checkIndex < 0)
            {
                break;
            }

            if (_blockList[checkIndex].Label.BackColor != Color.White)
            {
                Color color = _blockList[checkIndex].Label.BackColor;

                if (!colors.ContainsKey(color))
                {
                    colors[color] = new List<int>();
                }

                colors[color].Add(checkIndex);
                break;
            }
        }

        checkIndex = index;

        for (int i = y; i < _rowCount - 1; i++)
        {
            checkIndex += _rowSize;

            if (checkIndex > 344)
            {
                break;
            }

            if (_blockList[checkIndex].Label.BackColor != Color.White)
            {
                Color color = _blockList[checkIndex].Label.BackColor;

                if (!colors.ContainsKey(color))
                {
                    colors[color] = new List<int>();
                }

                colors[color].Add(checkIndex);
                break;
            }
        }

        if (colors.Count <= 1)
        {
            return;
        }

        foreach (var color in colors)
        {
            if (color.Value.Count >= 2)
            {
                foreach (var indexX in color.Value)
                {
                    _score++;
                    BlockDestroyEffect(indexX);
                    // _blockList[indexX].Timer.Start();
                    // _blockList[indexX].Label.BackColor = Color.White;
                }
            }
        }
        
        if (colors.Any(c => c.Key != Color.White && c.Value.Count >= 2))
        {
            SoundPlay("Blop-Sound.mp3", 0.3f);
        }
    }

    // 블럭 삭제 이펙트
    private void BlockDestroyEffect(int index)
    {
        _blockList[index].Timer.Start();
    }

    // 모든 블럭 비우기
    private void ClearBlock()
    {
        if (_blockList.Count > 1)
        {
            foreach (var block in _blockList)
            {
                Controls.Remove(block.Label);
            }

            _blockList.Clear();
        }
    }

    // 블럭 클릭 비활성화
    private void DisableBlock()
    {
        foreach (var block in _blockList)
        {
            block.Label.Enabled = false;
        }
    }

    // 테마 변경
    private void ThemeChange()
    {
        switch (_backColorCount)
        {
            default:
                _backColorCount = 0;
                this.BackColor = Color.Silver;
                gameButton.BackColor = Color.Gainsboro;
                gameButton.FlatAppearance.BorderColor = Color.Gray;
                borderButton.BackColor = Color.Gainsboro;
                borderButton.FlatAppearance.BorderColor = Color.Gray;
                backColorButton.BackColor = Color.Gainsboro;
                backColorButton.FlatAppearance.BorderColor = Color.Gray;
                highScoreLabel.BackColor = Color.Gray;
                scoreLabel.BackColor = Color.Gray;
                break;
            case 1:
                this.BackColor = Color.DimGray;
                gameButton.BackColor = Color.Silver;
                gameButton.FlatAppearance.BorderColor = Color.DimGray;
                borderButton.BackColor = Color.Silver;
                borderButton.FlatAppearance.BorderColor = Color.DimGray;
                backColorButton.BackColor = Color.Silver;
                backColorButton.FlatAppearance.BorderColor = Color.DimGray;
                highScoreLabel.BackColor = Color.Gainsboro;
                scoreLabel.BackColor = Color.Gainsboro;
                break;
            case 2:
                this.BackColor = Color.Pink;
                gameButton.BackColor = Color.MistyRose;
                gameButton.FlatAppearance.BorderColor = Color.Gray;
                borderButton.BackColor = Color.MistyRose;
                borderButton.FlatAppearance.BorderColor = Color.Gray;
                backColorButton.BackColor = Color.MistyRose;
                backColorButton.FlatAppearance.BorderColor = Color.Gray;
                highScoreLabel.BackColor = Color.Gainsboro;
                scoreLabel.BackColor = Color.Gainsboro;
                break;
            case 3:
                this.BackColor = Color.PaleGreen;
                gameButton.BackColor = Color.Ivory;
                gameButton.FlatAppearance.BorderColor = Color.DimGray;
                borderButton.BackColor = Color.Ivory;
                borderButton.FlatAppearance.BorderColor = Color.DimGray;
                backColorButton.BackColor = Color.Ivory;
                backColorButton.FlatAppearance.BorderColor = Color.DimGray;
                highScoreLabel.BackColor = Color.Gainsboro;
                scoreLabel.BackColor = Color.Gainsboro;
                break;
        }
    }
    
    // 효과음 재생
    private void SoundPlay(string filePath, float volume)
    {
        // 새로운 WaveOutEvent와 AudioFileReader를 생성
        var waveOut = new WaveOutEvent();
        var audioFileReader = new AudioFileReader(filePath);

        // 새로 생성된 WaveOutEvent와 AudioFileReader 초기화
        waveOut.Init(audioFileReader);
        waveOut.Volume = volume; // 볼륨 설정

        if (muteCheckBox.Checked)
        {
            waveOut.Volume = 0;
        }

        // 재생 시작
        waveOut.Play();

        // 리스트에 추가하여 추후 관리
        _waveOuts.Add(waveOut);
        _audioFileReaders.Add(audioFileReader);
    }

    // 게임 시간 타이머
    private void Timer_Tick(object sender, EventArgs e)
    {
        // 시간 종료
        if (_countTime <= 0)
        {
            // 최고 점수 갱신
            if (_highScore < _score)
            {
                _highScore = _score;
                highScoreLabel.Text = $@"{_highScore}";
            }

            SoundPlay("correct-8-ascending.mp3", 0.5f);
            Initialize();
            StopGame();
        }

        _countTime--;
        playTimeBar.Value = _countTime;
        scoreLabel.Text = @$"{_score}";
    }

    // 블럭 클릭
    private void Label_Click(object? sender, EventArgs e)
    {
        Label? clickedLabel = sender as Label;

        // 빈 블럭이면 중단
        if (clickedLabel != null && clickedLabel.BackColor != Color.White)
        {
            return;
        }

        // 예외 처리
        if (clickedLabel != null && clickedLabel.Tag != null)
        {
            GetCheckList((int)clickedLabel.Tag);
        }
    }

    // 게임 시작 버튼
    private void gameButton_Click(object sender, EventArgs e)
    {
        switch (gameButton.Text)
        {
            case @"게임 시작":
                StartGame();
                break;
            case @"중단":
                StopGame();
                break;
        }
    }

    // 블럭 테두리 변경
    private void borderButton_Click(object sender, EventArgs e)
    {
        foreach (var block in _blockList)
        {
            switch (block.Label.BorderStyle)
            {
                case BorderStyle.None:
                    block.Label.BorderStyle = BorderStyle.FixedSingle;
                    _tempBlock.Label.BorderStyle = BorderStyle.FixedSingle;
                    break;
                case BorderStyle.FixedSingle:
                    block.Label.BorderStyle = BorderStyle.Fixed3D;
                    _tempBlock.Label.BorderStyle = BorderStyle.Fixed3D;
                    break;
                case BorderStyle.Fixed3D:
                    block.Label.BorderStyle = BorderStyle.None;
                    _tempBlock.Label.BorderStyle = BorderStyle.None;
                    break;
            }
        }
    }

    // 게임 배경 색 변경
    private void backColorButton_Click(object sender, EventArgs e)
    {
        _backColorCount++;
        ThemeChange();
    }
}